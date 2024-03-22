using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chinh_That.BLL;
using Chinh_That.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chinh_That
{
    public partial class ADDACCOUNT : Form
    {
        public ADDACCOUNT()
        {
            InitializeComponent();
        }

        int ID;
        private string role_name;
        public ADDACCOUNT(int ID, string role_name)
        {
            InitializeComponent();
            this.ID = ID;
            this.role_name = role_name;
            comboBox1.Items.Clear();
            if (role_name == "Admin")
            {
                comboBox1.Items.Add("Admin");
                comboBox1.Items.Add("staff");
                comboBox1.Items.Add("customer");
            }
            else if (role_name == "staff")
            {
                comboBox1.Items.Add("customer");
            }
        }

        public ADDACCOUNT(String user_name,String user_password, String user_role, String role_name, int ID)
        {
            InitializeComponent();
            textBox1.Text = user_name;
            textBox1.ReadOnly= true;
            textBox2.Text = user_password;
            this.ID = ID;
            this.role_name = role_name;
            comboBox1.Items.Clear();
            if (role_name == "Admin")
            {
                comboBox1.Items.Add("Admin");
                comboBox1.Items.Add("staff");
                comboBox1.Items.Add("customer");
            }
            else if (role_name == "staff")
            {
                comboBox1.Items.Add("customer");
            }
            comboBox1.SelectedItem = user_role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID== 0)
            {
                user us = new user();
                us.user_name = textBox1.Text;
                us.user_password = textBox2.Text;
                user_role usr = new user_role();
                usr.user_name = textBox1.Text;
                usr.role_name = comboBox1.SelectedItem.ToString();
                TaiKhoan_BLL.Instance.add_BLL(us);
                TaiKhoan_BLL.Instance.addRole_BLL(usr);
                string s = "0:0:0";
                TTKH_BLL.Instance.add_BLL(us.user_name, s, false);
            }
            else if (ID== 1)
            {
                user us = new user();
                us.user_name = textBox1.Text;
                us.user_password = textBox2.Text;
                user_role ur = new user_role();
                ur.user_name = textBox1.Text;
                ur.role_name = comboBox1.SelectedItem.ToString();
                TaiKhoan_BLL.Instance.update_BLL(us.user_name, us, ur);
            }
        }
    }
}
