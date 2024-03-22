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

namespace Chinh_That
{
    public partial class QLTAIKHOAN : Form
    {
        public QLTAIKHOAN(String role)
        {
            InitializeComponent();
            this.role_name = role;
        }
        private string role_name;

        private void but_add_Click(object sender, EventArgs e)
        {
            ADDACCOUNT addac = new ADDACCOUNT(0,role_name);

            if (addac.ShowDialog() == DialogResult.OK)
            {

                load();
            }
        }

        public void load()
        {
            DataTable dt = new DataTable();
            dt = TaiKhoan_BLL.Instance.getAllTK();
            dataGridView1.DataSource = dt;

        }

        private void QLTAIKHOAN_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Bạn chưa chọn hàng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ADDACCOUNT ag = new ADDACCOUNT(dataGridView1.CurrentRow.Cells["user_name"].Value.ToString(), dataGridView1.CurrentRow.Cells["user_password"].Value.ToString(), dataGridView1.CurrentRow.Cells["user_role"].Value.ToString(),role_name, 1);
                if (ag.ShowDialog() == DialogResult.OK)
                {

                    load();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
