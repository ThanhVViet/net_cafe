using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chinh_That.BLL;
using Chinh_That.DTO;

namespace Chinh_That
{
    public partial class UserControl_COM : UserControl
    {    
        public UserControl_COM(string com, int id, string NSX, string Wa, string IP, Boolean activestatus, String user_name)
        {
            InitializeComponent();
            lbCom.Text = com;
            lbID.Text = id.ToString();
            lbNSX.Text = NSX;
            lbWa.Text = Wa;
            lbIP.Text = IP;
            lbUser.Text = user_name;
            if (activestatus)
            {
                lbCom.BackColor = Color.Firebrick;
            }
            else lbCom.BackColor = Color.ForestGreen;
        }

        private void btnDel_Com_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa máy này không ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {             
                int lb = Convert.ToInt32(lbID.Text);
                MayTinh_BLL.Instance.delCom(lb);
                this.Dispose();
            }
        }

        private void btnEdit_Com_Click(object sender, EventArgs e)
        {
            computer cp = new computer();
            cp.id = Convert.ToInt32(lbID.Text);
            cp.num_com = Convert.ToInt32(lbCom.Text);
            cp.manufacturer = lbNSX.Text;
            cp.warranty = lbWa.Text;
            cp.ip = lbIP.Text;
            fCOM k = new fCOM(1, cp);
            k.nemdl += fCom_nemdl;
            k.ShowDialog();
        }
       
        private void fCom_nemdl(computer computer)
        {
            lbCom.Text = computer.num_com.ToString();
            lbIP.Text = computer.ip;
            lbNSX.Text = computer.manufacturer;
            lbWa.Text = computer.warranty;
        }
     
    }
}
