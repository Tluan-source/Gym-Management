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
using Guna.UI2.WinForms;
using System.Web.Security;
using GymManagemement.Connection;

namespace GymManagemement
{
    public partial class Addmembership : System.Windows.Forms.Form
    {
        private bool isEditMode = false;
        public Loadmembership CurrentMembershipData { get; private set; }
        public Loadmembership NewMembershipData { get; set; }

        public Addmembership(Loadmembership membershipToEdit) : this()
        {
            isEditMode = true;
            CurrentMembershipData = membershipToEdit;
        }

        public Addmembership()
        {
            InitializeComponent();
            lb_duration.Text = "Days";
            lb_price.Text = "VNĐ";
            lb_name.Text = "Name";
            cb_time.Size = new Size(89, 23);
            lb_title.Text = isEditMode ? "Edit selected membership" : "Add new membership";
        }

        #region TextChangedEvent
        private void txt_name_TextChanged(object sender, EventArgs e) => lb_name.Text = txt_name.Text;

        private void txt_durationdays_TextChanged(object sender, EventArgs e)
        {
            if (IsValidDuration(txt_durationdays.Text))
            {
                lb_duration.ForeColor = Color.Black;
                lb_duration.Text = txt_durationdays.Text + " " + cb_time.Text;
            }
            else
            {
                lb_duration.ForeColor = Color.Red;
                lb_duration.Text = "ERROR!";
            }
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(txt_price.Text.Replace(".", ""), out long value))
                lb_price.Text = value.ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + " VNĐ"; // Tự động thêm dấu chấm
            else
                lb_price.Text = "0 VNĐ";
        }

        private void cb_time_SelectedIndexChanged(object sender, EventArgs e) => txt_durationdays_TextChanged(null, null);

        private bool IsValidDuration(string text)
        {
            if (int.TryParse(text, out int value))
            {
                if (cb_time.SelectedIndex == 0) // Days
                    return value >= 1 && value <= 30;
                else if (cb_time.SelectedIndex == 1) // Months
                    return value >= 1 && value <= 12;
                else if (cb_time.SelectedIndex == 2) // Years
                    return value >= 1 && value <= 10;
            }
            return false;
        }
        #endregion

        #region KeyPressEvent
        private void OnlyDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
        private void txt_durationdays_KeyPress(object sender, KeyPressEventArgs e)  => OnlyDigit_KeyPress(sender, e);
        private void txt_price_KeyPress(object sender, KeyPressEventArgs e) => OnlyDigit_KeyPress(sender, e);

        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }
        }

        #endregion
        #region ClickEvent
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            
            int durationValue = int.Parse(txt_durationdays.Text);
            int totalDays = 0;

            switch (cb_time.SelectedIndex)
            {
                case 0: // Ngày
                    totalDays = durationValue;
                    break;
                case 1: // Tháng
                    totalDays = durationValue * 30;
                    break;
                case 2: // Năm
                    totalDays = durationValue * 365;
                    break;
                default:
                    MessageBox.Show("Please fill in valid Time.");
                    cb_time.Focus();
                    return;
            }

            NewMembershipData = new Loadmembership
            {
                Name = lb_name.Text,
                Durations = totalDays.ToString(),
                Price = txt_price.Text,
            };

            DialogResult = DialogResult.OK; // Đặt kết quả của hộp thoại là OK
            Close(); // Đóng hộp thoại
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Addmembership_Load(object sender, EventArgs e)
        {
            var service = new Service.Load_Membership();
            txt_ID.Text = service.GetNextMembershipId();
            txt_ID.ReadOnly = true;
            lb_ID.Text = "ID: " + txt_ID.Text;

            if (isEditMode && CurrentMembershipData != null)
            {
                btn_add.Visible = false;
                btn_savett.Visible = true;

                txt_ID.Text = CurrentMembershipData.Id;
                txt_ID.Enabled = false;

                txt_name.Text = CurrentMembershipData.Name;

                //xử lí chữ VNĐ
                string price_digits = new string(CurrentMembershipData.Price.Where(char.IsDigit).ToArray());
                txt_price.Text = price_digits;

                //xử lí load duration từ days lên bảng edit, 
                int days;

                if (!int.TryParse(CurrentMembershipData.Durations, out days))
                {
                    string digits = new string(CurrentMembershipData.Durations.Where(char.IsDigit).ToArray());
                    days = int.Parse(digits);
                }

                if (days % 365 == 0)
                {
                    cb_time.SelectedIndex = 2;
                    txt_durationdays.Text = (days / 365).ToString();
                }
                else if (days % 30 == 0)
                {
                    cb_time.SelectedIndex = 1;
                    txt_durationdays.Text = (days / 30).ToString();
                }
                else
                {
                    cb_time.SelectedIndex = 0;
                    txt_durationdays.Text = days.ToString();
                }
            }
        }
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            int durationValue = int.Parse(txt_durationdays.Text);
            int totalDays = 0;

            switch (cb_time.SelectedIndex)
            {
                case 0: // Ngày
                    totalDays = durationValue;
                    break;
                case 1: // Tháng
                    totalDays = durationValue * 30;
                    break;
                case 2: // Năm
                    totalDays = durationValue * 365;
                    break;
                default:
                    MessageBox.Show("Please select the time unit.");
                    cb_time.Focus();
                    return;
            }

            CurrentMembershipData.Name = txt_name.Text.Trim();
            CurrentMembershipData.Durations = totalDays.ToString();
            CurrentMembershipData.Price = txt_price.Text.Trim();

            string err = "";
            var service = new Service.Load_Membership();
            bool ok = service.UpdateMemberShip(CurrentMembershipData, ref err);

            if(ok)
            {
                MessageBox.Show("Successfully!", "Noti", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("update error: " + err + "Error: ");
            }
        }

        private bool ValidateFields()
        {
            txt_name.Text = txt_name.Text.Trim();
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Please fill in a valid name (no blanks or spaces).");
                txt_name.Focus();
                return false;
            }

            txt_durationdays.Text = txt_durationdays.Text.Trim();
            if (!IsValidDuration(txt_durationdays.Text))
            {
                MessageBox.Show("Please fill in valid day, month, year (no blanks or spaces).");
                txt_durationdays.Focus();
                return false;
            }

            txt_price.Text = txt_price.Text.Trim();
            if (!int.TryParse(txt_price.Text, out _))
            {
                MessageBox.Show("Please fill in a valid price (no blanks or spaces).");
                txt_price.Focus();
                return false;
            }

            return true;
        }
    }
}
