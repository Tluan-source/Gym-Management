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
            flp_member.Controls.Clear();
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
                string query = @"
                SELECT DISTINCT mbs.name AS namembs 
                FROM members mb 
                JOIN memberships mbs ON mb.membership_id = mbs.membership_id";

                DataSet ds = db.ExecuteQueryData(query, CommandType.Text);

                if (ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];

                    //Thêm hàng "None" vào đầu
                    DataRow row = table.NewRow();
                    row["namembs"] = "None";
                    table.Rows.InsertAt(row, 0);

                    cb_mbstype.DataSource = table;
                    cb_mbstype.DisplayMember = "namembs";
                    cb_mbstype.ValueMember = "namembs";
                }

                //MessageBox.Show(cb_mbstype.ValueMember, cb_mbstype.DisplayMember);

                string query2 = "SELECT DISTINCT training_type FROM members";
                DataSet ds2 = db.ExecuteQueryData(query2, CommandType.Text);

                cb_traintype.DataSource = ds2.Tables[0];
                cb_traintype.DisplayMember = cb_traintype.ValueMember = "training_type";
                string query3 = "SELECT DISTINCT mb.trainer_id id_trainer, t.full_name name_trainer FROM members mb JOIN trainers t ON mb.trainer_id = t.trainer_id";
                DataSet ds3 = db.ExecuteQueryData(query3, CommandType.Text);

                cb_trainer.DataSource = ds3.Tables[0];
                cb_trainer.DisplayMember = "name_trainer";
                cb_trainer.ValueMember = "id_trainer";
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
                if(ctrl is UCLoadmember ucLoadmember)
                {
                    string membername = ucLoadmember.currentMemberData?.FullName?.ToLower() ?? "";

                    ucLoadmember.Visible = membername.Contains(keyword);
                }
            }
        }
        private void cb_mbstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cb_mbstype.Text;
            foreach (Control ctrl in flp_member.Controls)
            {
                if (ctrl is UCLoadmember ucLoadmember)
                {
                    string mbstype = ucLoadmember.currentMemberData?.Membership ?? "";
                    if(cb_mbstype.SelectedIndex == 0)
                    {
                        ucLoadmember.Visible = true;
                    }
                    else
                    {
                        ucLoadmember.Visible = mbstype.Contains(selectedValue);
                    }
                }
            }
        }
    }
}
