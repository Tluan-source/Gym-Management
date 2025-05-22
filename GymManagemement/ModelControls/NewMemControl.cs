using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagemement.NewMembers
{
    public partial class NewMemControl : UserControl
    {
        public NewMemControl()
        {
            InitializeComponent();
        }
        public void SetData(NewMember data)
        {
            lbName.Text = data.Name;
            lbTime.Text = data.RegisteredAt;
            
        }
    }
}
