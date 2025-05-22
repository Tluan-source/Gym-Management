using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagemement.Service;


namespace GymManagemement
{
    public partial class UCLoadmember : UserControl
    {
        public event Action MemberUpdated;
        public Loadmember currentMemberData { get; set; }
        public UCLoadmember()
        {
            InitializeComponent();
        }
        
        public void Setdata(Loadmember data)
        {
            currentMemberData = data; // Lưu dữ liệu thành viên hiện tại
            lb_ID.Text = data.Id;
            lb_FULLNAME.Text = data.FullName;
            lb_PHONE.Text = data.Phone;
            lb_EMAIL.Text = data.Email;
            lb_GENDER.Text = data.Gender;
            lb_DOB.Text = data.DateOfBirth.ToString("dd/MM/yyyy");
            lb_JOINDATE.Text = data.JoinDate.ToString("dd/MM/yyyy");
            lb_MEMBERSHIP.Text = data.Membership;
            lb_TRAININGTYPE.Text = data.TrainingType;
            lb_TRAINER.Text = data.Trainer;
        }
        private void UCLoadmember_MouseLeave(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                btn_delete.Visible = false;
                btn_edit.Visible = false;
            }
        }

        private void UCLoadmember_MouseEnter(object sender, EventArgs e)
        {
            btn_delete.Visible = true;
            btn_edit.Visible = true;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            deletemem();
        }
        private void deletemem()
        {
            string id = lb_ID.Text;
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Load_Member member = new Load_Member();
                string err = string.Empty;

                // Create a Loadmember object with the ID to delete
                Loadmember memberToDelete = new Loadmember { Id = id };

                if (member.DeleteMember(memberToDelete, ref err))
                {
                    MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            editmem();
            
        }
        private void editmem()
        {
            var updateForm = new Addmem(currentMemberData);

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                // Lấy dữ liệu đã update
                var updated = updateForm.CurrentMemberData;

                // Cập nhật DB
                var service = new Load_Member();
                string err = null;
                if (service.UpdateMember(updated, ref err))
                {
                    // Cập nhật UI ngay trên control này
                    Setdata(updated);
                    MemberUpdated?.Invoke(); // Gọi sự kiện cập nhật thành viên
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + err, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
