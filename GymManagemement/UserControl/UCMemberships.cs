using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagemement.Service;

namespace GymManagemement
{
    public partial class UCMemberships : UserControl
    {
        public UCMemberships()
        {
            InitializeComponent();
        }
        private void LoadDataMembership()
        {
            Load_Membership membership = new Load_Membership();
            List<Loadmembership> memberships = membership.GetMembership();
            flp_memberships.Controls.Clear();
            try
            {
                flp_memberships.Controls.Clear();
                foreach (var item in memberships)
                {
                    var ctrl = new UCLoadmembership();
                    ctrl.Setdata(item);
                    //ctrl.MembershipUpdated += () => LoadDataMembership(); // Đăng ký sự kiện cập nhật thành viên
                    flp_memberships.Controls.Add(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UCMemberships_Load(object sender, EventArgs e)
        {
            LoadDataMembership();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Addmembership addmembership = new Addmembership();
            
            var result = addmembership.ShowDialog(); // Hiện form Addmem

            if (result == DialogResult.OK && addmembership.NewMembershipData != null)
            {
                var newMembership = addmembership.NewMembershipData;
                var service = new Load_Membership();
                string err = string.Empty; // Declare and initialize the 'err' variable
                service.AddMembership(newMembership, ref err); // đảm bảo bạn có hàm AddMember()

                if (string.IsNullOrEmpty(err))
                {
                    MessageBox.Show("Thêm gói thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataMembership(); // Tải lại dữ liệu thành viên
                }
                else
                {
                    MessageBox.Show("Lỗi: " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadDataMembership();
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadDataMembership();
        }
    }
}
