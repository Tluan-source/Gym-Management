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
    public partial class UcMemExpired : UserControl
    {
        public UcMemExpired()
        {
            InitializeComponent();
        }
        public void SetData(MemExpired mem)
        {
            lbName.Text = mem.Name;
            lbMemShip.Text = mem.MemShip;
            lbPhone.Text = mem.Phone;
        }
    }
}
