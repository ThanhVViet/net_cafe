using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinh_That
{
    public partial class BILLS : UserControl
    {
        public BILLS()
        {
            InitializeComponent();
        }

        private void buttonMini_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BILLS_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            int s = 0;
            foreach (CARTITEM ci in flowLayoutPanel1.Controls)
            {
                s += (Convert.ToInt32(ci.lbPrice.Text.TrimEnd('đ')) * Convert.ToInt32(ci.txbSoLuong.Text));
            }
            BILLS ac = new BILLS();
            ac = (BILLS)flowLayoutPanel1.Parent;
            ac.lbMoney.Text = s.ToString() + "đ";
        }
    }
}
