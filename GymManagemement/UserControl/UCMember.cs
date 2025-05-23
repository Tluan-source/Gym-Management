using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagemement.Connection;
using GymManagemement.Service;

namespace GymManagemement
{
    public partial class UCMember : UserControl
    {
        public UCMember()
        {
            InitializeComponent();
        }
        private void LoadDataMember()
        {
            Load_Member member = new Load_Member();
            List<Loadmember> members = member.Getmember();
            try { 
                flp_member.Controls.Clear();
                foreach (var item in members)
                {
                    var ctrl = new UCLoadmember();
                    ctrl.Setdata(item);
                    ctrl.MemberUpdated += () => LoadDataMember(); // Đăng ký sự kiện cập nhật thành viên
                    flp_member.Controls.Add(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCMember_Load(object sender, EventArgs e)
        {
            LoadDataMember();
            Loadmembershiptype();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Addmem addmem = new Addmem();

            var result = addmem.ShowDialog(); // Hiện form Addmem  

            if (result == DialogResult.OK && addmem.NewMemberData != null)
            {
                var newMember = addmem.NewMemberData;

                // Thêm vào cơ sở dữ liệu hoặc danh sách (nếu bạn đã có)  
                var service = new Load_Member();
                string err = string.Empty; // Declare and initialize the 'err' variable  
                service.AddMember(newMember, ref err); // đảm bảo bạn có hàm AddMember()  

                if (!string.IsNullOrEmpty(err))
                {
                    MessageBox.Show("Error: " + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Load lại danh sách để hiển thị  
                LoadDataMember();
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadDataMember();
        }
        private void Loadmembershiptype()
        {
            try
            {

                ConnDB db = new ConnDB();

                // 1. Load membership types
                string query = @"
                SELECT DISTINCT mbs.name AS namembs 
                FROM members mb 
                JOIN memberships mbs ON mb.membership_id = mbs.membership_id";

                DataSet ds = db.ExecuteQueryData(query, CommandType.Text);

                if (ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];

                    DataRow row = table.NewRow();
                    row["namembs"] = "None";
                    table.Rows.InsertAt(row, 0);

                    cb_mbstype.DataSource = table;
                    cb_mbstype.DisplayMember = "namembs";
                    cb_mbstype.ValueMember = "namembs";
                }

                // 2. Load training types
                string query2 = "SELECT DISTINCT training_type FROM members";
                DataSet ds2 = db.ExecuteQueryData(query2, CommandType.Text);

                DataTable dt = ds2.Tables[0];

                DataRow newRow = dt.NewRow();
                newRow["training_type"] = "None";
                dt.Rows.InsertAt(newRow, 0);

                cb_traintype.DataSource = dt;
                cb_traintype.DisplayMember = "training_type";
                cb_traintype.ValueMember = "training_type";

                // 3. Load trainer list
                string query3 = @"
                SELECT DISTINCT mb.trainer_id AS id_trainer, t.full_name AS name_trainer
                FROM members mb 
                JOIN trainers t ON mb.trainer_id = t.trainer_id";

                DataSet ds3 = db.ExecuteQueryData(query3, CommandType.Text);

                if (ds3.Tables.Count > 0)
                {
                    DataTable dt3 = ds3.Tables[0];

                    DataRow row3 = dt3.NewRow();
                    row3["id_trainer"] = DBNull.Value; // hoặc "", nếu bạn dùng chuỗi rỗng
                    row3["name_trainer"] = "None";
                    dt3.Rows.InsertAt(row3, 0);

                    cb_trainer.DataSource = dt3;
                    cb_trainer.DisplayMember = "name_trainer";
                    cb_trainer.ValueMember = "id_trainer";
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi khi load dữ liệu lên cb_mbstype: " + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = tb_search.Text.Trim().ToLower();

            foreach (Control ctrl in flp_member.Controls)
            {
                if(ctrl is UCLoadmember searchbyName)
                {
                    string membername = searchbyName.currentMemberData?.FullName?.ToLower() ?? "";

                    searchbyName.Visible = membername.Contains(keyword);
                }
            }
        }
        private void cb_mbstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cb_mbstype.Text;
            foreach (Control ctrl in flp_member.Controls)
            {
                if (ctrl is UCLoadmember searchbyMbstype)
                {
                    string mbstype = searchbyMbstype.currentMemberData?.Membership ?? "";
                    if(cb_mbstype.SelectedIndex == 0) searchbyMbstype.Visible = true;
                    else searchbyMbstype.Visible = mbstype.Contains(selectedValue);
                }
            }
        }

        private void cb_traintype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTrainType = cb_traintype.Text;
            foreach (Control ctrl in flp_member.Controls)
            {
                if(ctrl is UCLoadmember searchbyTraintype)
                {
                    string traintype = searchbyTraintype.currentMemberData?.TrainingType ?? "";
                    if(cb_traintype.SelectedIndex == 0) searchbyTraintype.Visible = true;
                    else searchbyTraintype.Visible = traintype.Contains(selectedTrainType);
                }
            }
        }

        private void cb_trainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTrainer = cb_trainer.Text;
            foreach (Control ctrl in flp_member.Controls)
            {
                if(ctrl is UCLoadmember searchbyTrainer)
                {
                    string trainer = searchbyTrainer.currentMemberData?.Trainer ?? "";
                    if(cb_trainer.SelectedIndex == 0) searchbyTrainer.Visible = true;
                    else searchbyTrainer.Visible= trainer.Contains(selectedTrainer);
                }
            }
        }
    }
}
