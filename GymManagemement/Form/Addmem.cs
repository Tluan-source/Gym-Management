using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using GymManagemement.Connection;

namespace GymManagemement
{
    public partial class Addmem : System.Windows.Forms.Form
    {
        private string selectedGender = "";
        private string selectedMembership = "";
        private string selectedTrainingType = "";
        //private string selectedTrainer = "";
        public Loadmember NewMemberData { get; private set; }
        public Loadmember CurrentMemberData { get; private set; }
        private bool isEditMode = false;
        public event EventHandler Moreclick;
        public Addmem(Loadmember memberToEdit) : this()  // gọi constructor mặc định để InitializeComponent
        {
            isEditMode = true;
            CurrentMemberData = memberToEdit;
        }
        public Addmem()
        {
            InitializeComponent();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số và phím điều khiển như Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Giới hạn tối đa 10 chữ số
            if (!char.IsControl(e.KeyChar) && txt_phone.Text.Length >= 10)
            {
                e.Handled = true; // Chặn nếu đã đủ 10 ký tự
            }
        }
        private void txt_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép chữ cái, số, dấu chấm, gạch dưới, @, và phím điều khiển (Backspace...)
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '@')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }
        private bool IsValidGmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[a-zA-Z0-9._%+-]+@gmail\.com$"
            );
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!IsValidGmail(txt_email.Text))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ có đuôi @gmail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_email.Focus();
                return;
            }
            if (string.IsNullOrEmpty(selectedGender))
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_fullname.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NewMemberData = new Loadmember
            {
                FullName = txt_fullname.Text.Trim(),
                Email = txt_email.Text.Trim(),
                Phone = txt_phone.Text.Trim(),
                Gender = selectedGender,
                Membership = selectedMembership,
                TrainingType = selectedTrainingType,

                DateOfBirth = dtp_DoB.Value,
                JoinDate = dtp_joindate.Value,
                Trainer = null,
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_clearname_Click(object sender, EventArgs e)
        {
            txt_fullname.Clear();
        }

        private void Addmem_Load(object sender, EventArgs e)
        {
            LoadMemberships();
            var service = new Service.Load_Member();
            txt_id.Text = service.GetNextMemberId();
            txt_id.ReadOnly = true;
            if (isEditMode)
            {
                btn_add.Visible = false;
                btn_save.Visible = true;
                //ID
                txt_id.Text = CurrentMemberData.Id;
                txt_id.Enabled = false;

                //textbox
                txt_fullname.Text = CurrentMemberData.FullName;
                txt_email.Text = CurrentMemberData.Email;
                txt_phone.Text = CurrentMemberData.Phone;

                //DTP
                dtp_DoB.Value = CurrentMemberData.DateOfBirth;
                dtp_joindate.Value = CurrentMemberData.JoinDate;

                //Gender
                selectedGender = CurrentMemberData.Gender;
                if (selectedGender == "Nam") HighlightGenderButton(btn_male);
                else if(selectedGender == "Nữ") HighlightGenderButton(btn_female);

                //Membership
                //chuyển currentMemberData.Mbs từ chuỗi sang int
                if (int.TryParse(CurrentMemberData.Membership, out int memId))
                {
                    bool exists = cb_membership.Items
                                        .Cast<DataRowView>()
                                        .Any(r => Convert.ToInt32(r["membership_id"]) == memId);
                    //nếu tồn tại trong danh sách thì gán giá trị
                    if (exists)
                    {
                        cb_membership.SelectedValue = memId;
                        selectedMembership = memId.ToString();
                    }
                    //nếu mà dạng "Luan" thì trả về -1 và rỗng
                    else
                    {
                        cb_membership.SelectedIndex = -1; // Không có trong danh sách
                        selectedMembership = "";
                    }
                }
                else
                {
                    cb_membership.SelectedIndex = -1;
                    selectedMembership = "";
                }

                //TrainingType
                selectedTrainingType = CurrentMemberData.TrainingType;
                if(selectedTrainingType == "Solo") HighlightTrainingTypeButton(btn_none);
                else if (selectedTrainingType == "PT") HighlightTrainingTypeButton(btn_pt);
            }
            else
            {
                btn_add.Visible = true;
                btn_save.Visible = false;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!IsValidGmail(txt_email.Text))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ có đuôi @gmail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_email.Focus();
                return;
            }
            if (string.IsNullOrEmpty(selectedGender))
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_fullname.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CurrentMemberData.FullName = txt_fullname.Text.Trim();
            CurrentMemberData.Email = txt_email.Text.Trim();
            CurrentMemberData.Phone = txt_phone.Text.Trim();
            CurrentMemberData.Gender = selectedGender;
            CurrentMemberData.Membership = selectedMembership;
            CurrentMemberData.TrainingType = selectedTrainingType;
            CurrentMemberData.DateOfBirth = dtp_DoB.Value;
            CurrentMemberData.JoinDate = dtp_joindate.Value;
            string err = "";
            var service = new Service.Load_Member();
            bool ok = service.UpdateMember(CurrentMemberData, ref err);
            if (ok)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region ----UI GENDER----
        private void btn_male_Click(object sender, EventArgs e)
        {
            selectedGender = "Nam";
            HighlightGenderButton(btn_male);
        }
        private void btn_female_Click(object sender, EventArgs e)
        {
            selectedGender = "Nữ";
            HighlightGenderButton(btn_female);
        }
        private void HighlightGenderButton(Guna.UI2.WinForms.Guna2Button selectedBtn)
        {
            // Reset màu tất cả nút
            btn_male.FillColor = SystemColors.Control;
            btn_female.FillColor = SystemColors.Control;

            selectedBtn.FillColor = Color.FromArgb(128, 255, 255);
        }
        #endregion

        #region ----UI TRAINING TYPE----
        private void btn_none_Click(object sender, EventArgs e)
        {
            selectedTrainingType = "Solo";
            HighlightTrainingTypeButton(btn_none);
            btn_choosetrainer.FillColor = SystemColors.Control;
            btn_choosetrainer.Enabled = false;
        }

        private void btn_pt_Click(object sender, EventArgs e)
        {
            selectedTrainingType = "PT";
            HighlightTrainingTypeButton(btn_pt);
            btn_choosetrainer.FillColor = Color.RoyalBlue;
            btn_choosetrainer.Enabled = true;
        }
        private void HighlightTrainingTypeButton(Guna.UI2.WinForms.Guna2Button selectedBtn)
        {
            // Reset màu tất cả nút
            btn_none.FillColor = SystemColors.Control;
            btn_pt.FillColor = SystemColors.Control;
            selectedBtn.FillColor = Color.LightPink;
        }
        #endregion
        private void LoadMemberships()
        {
            try
            {
                ConnDB db = new ConnDB();
                string query = "SELECT membership_id, name FROM memberships";
                DataSet ds = db.ExecuteQueryData(query, CommandType.Text);

                cb_membership.DataSource = ds.Tables[0];
                cb_membership.DisplayMember = "name";
                cb_membership.ValueMember = "membership_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load membership: " + ex.Message);
            }
        }

        private void cb_membership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_membership.SelectedValue != null)
                selectedMembership = cb_membership.SelectedValue.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Moreclick?.Invoke(this, EventArgs.Empty);
        }
    }
}

