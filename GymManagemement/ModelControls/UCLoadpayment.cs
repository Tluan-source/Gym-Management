using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagemement
{
    public partial class UCLoadpayment : UserControl
    {
        public UCLoadpayment()
        {
            InitializeComponent();
        }
        public void Setdata(Loadpayment data)
        {
            lb_ID.Text = data.Id;
            lb_customer.Text = data.Customer;
            lb_amount.Text = data.Amount;
            lb_date.Text = data.Date;
            lb_status.Text = data.Status;
        }
    }
}
