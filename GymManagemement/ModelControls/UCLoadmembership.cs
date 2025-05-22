using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagemement.Service;

namespace GymManagemement
{
    public partial class UCLoadmembership : UserControl
    {
        public event Action MembershipUpdated;
        private Loadmembership currentMembershipData;
        public UCLoadmembership()
        {
            InitializeComponent();
        }
        public void Setdata(Loadmembership data)
        {
            currentMembershipData = data;
            //lọc chỉ lấy số và tạo thành 1 mảng kí tự, ví dụ trong data là "1.000.00" thì sẽ 
            //tách ra là "1", "0", "0", "0", "0", "0", rùi ghép lại thành 1 chuỗi "100000"
            string numeric = new string(data.Price.Where(char.IsDigit).ToArray());
            lb_ID.Text = data.Id;
            lb_name.Text = data.Name;
            lb_duration.Text = data.Durations;
            //dòng này là chuyển chuỗi kiểu số thành int
            //nếu parse được thì cho nó có mấy dấu chấm kiểu VN
            if (int.TryParse(numeric, out int price))
            {
                lb_price.Text = price.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " VNĐ";
            }
            //nếu không parse được thì giữ nguyên như data
            else
            {
                lb_price.Text = data.Price; // nếu không parse được thì giữ nguyên
            }
            lb_quantity.Text = data.Quantity;
            lb_status.Text = data.status;
        }
        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!guna2Panel1.ClientRectangle.Contains(guna2Panel1.PointToClient(Cursor.Position)))
            {
                btn_delete.Visible = false;
                btn_edit.Visible = false;
            }
        }

        private void guna2Panel1_MouseEnter(object sender, EventArgs e)
        {
            btn_delete.Visible = true;
            btn_edit.Visible = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            deletemembership();
        }
        private int getintmembershipid()
        {
            if (string.IsNullOrEmpty(lb_ID.Text))
                return -1;

            // Lọc ra chỉ các chữ số từ chuỗi
            string numericPart = new string(lb_ID.Text.Where(char.IsDigit).ToArray());

            if (int.TryParse(numericPart, out int id))
                return id;

            return -1;
        }
        private void deletemembership()
        {
            // Lấy ID dạng số
            int memberId = getintmembershipid();

            if (memberId == -1)
            {
                MessageBox.Show("ID thành viên không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận xóa
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa thành viên #{memberId}?",
                                       "Xác nhận",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string error = string.Empty;
                Load_Membership membership = new Load_Membership();

                Loadmembership membershipToDelete = new Loadmembership
                {
                    Id = memberId.ToString()
                };
                if(membership.DeleteMembership(membershipToDelete, ref error))
                {
                    MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Parent.Controls.Remove(this); // Xóa điều khiển khỏi bố mẹ
                }
                else
                {
                    MessageBox.Show("Lỗi: " + error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void guna2PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            btn_delete.Visible = true;
            btn_edit.Visible = true;
        }

        private void guna2PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!guna2Panel1.ClientRectangle.Contains(guna2Panel1.PointToClient(Cursor.Position)))
            {
                btn_delete.Visible = false;
                btn_edit.Visible = false;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            editmembership();
        }
        private void editmembership()
        {
            var updateForm = new Addmembership(currentMembershipData);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                var updated = updateForm.CurrentMembershipData;

                var service = new Load_Membership();
                string err = null;
                if (service.UpdateMemberShip(updated, ref err))
                {
                    Setdata(updated);
                    MembershipUpdated?.Invoke();
                }
                else
                {
                    MessageBox.Show("Lỗi update mbs: " + err + "Lỗi");
                }
            }
        }
    }
}
