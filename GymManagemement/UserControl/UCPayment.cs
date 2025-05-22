using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagemement
{
    public partial class UCPayment : UserControl
    {
        public UCPayment()
        {
            InitializeComponent();
        }
        private void loaddatapayment()
        {
            flp_payment.Controls.Clear();
            List<Loadpayment> list = new List<Loadpayment>
            {
                new Loadpayment {Id = "#001", Customer = "Nguyen Thanh Luan", Amount = "5000000", Date = "2023-10-01", Status = "Paid"},
                new Loadpayment {Id = "#002", Customer = "Nguyen Thi Mai", Amount = "3000000", Date = "2023-09-15", Status = "Pending"},
                new Loadpayment {Id = "#003", Customer = "Le Van Cuong", Amount = "7000000", Date = "2023-08-20", Status = "Failed"},
            };
            foreach (var item in list)
            {
                var ctrl = new UCLoadpayment();
                ctrl.Setdata(item);
                flp_payment.Controls.Add(ctrl);
            }
            lb_totalmoney.Text = list.Sum(x => Convert.ToInt32(x.Amount)).ToString("N1", new CultureInfo("vi-VN")) + " VNĐ";
        }
        private void UCPayment_Load(object sender, EventArgs e)
        {
            loaddatapayment();
        }
    }
}
