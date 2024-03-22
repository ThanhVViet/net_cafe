using Chinh_That.DTO;
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
    public partial class AddEditTTKH : Form
    {
        public delegate void NemDL(string user_name, string money);
        
        int IDS;

        public AddEditTTKH()
        {
            InitializeComponent();
            
        }
        public AddEditTTKH(int iDS)
        {
            InitializeComponent();
            IDS = iDS;
        }
        public event NemDL nemdl = null;
        public AddEditTTKH(int iDS, customer obj)
        {
            InitializeComponent();
            txt_id.Text = obj.id.ToString();
            txt_username.Text = obj.user_name;
            txt_remainingtime.Text = obj.remaining_time;
            txt_username.ReadOnly= true;
            IDS = iDS;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txt_username.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản cần nạp tiền","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (txt_remainingtime.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiền cần nạp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (!TTKH_BLL.Instance.check_BLL(txt_username.Text))
                {
                    MessageBox.Show("Không tồn tại tài khoản trên","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (nemdl != null) nemdl(txt_username.Text, txt_remainingtime.Text);
                    this.Dispose();
                }
            }

        }

        private void AddEditTTKH_Load(object sender, EventArgs e)
        {

        }
    }
}
