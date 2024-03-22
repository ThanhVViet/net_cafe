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
    public partial class TTKHcs : Form
    {
        public TTKHcs()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            setDGV();
            timer1.Start();
        }
        public String username;
        public int money; 
        public void setDGV()
        {
            dgv.DataSource = TTKH_BLL.Instance.showdgv().DataSource;

        }

        private void but_Search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dgv.DataSource = TTKH_BLL.Instance.search_BLL(textBox1.Text).DataSource;
            }
            else
            {
                setDGV();
            }
        }

        private void but_Add_Click(object sender, EventArgs e)
        {
            using (AddEditTTKH addEdit = new AddEditTTKH(0))
            {
                if (addEdit.ShowDialog() == DialogResult.OK)
                {
                    setDGV();
                }
            }
        }

        private void but_edit_Click(object sender, EventArgs e)
        {
            string id = dgv.CurrentRow.Cells["id"].Value.ToString();

            customer c = TTKH_BLL.Instance.GetCustomerByID(Convert.ToInt32(id));
            using (AddEditTTKH addEdit = new AddEditTTKH(1, c))
            {
                if (addEdit.ShowDialog() == DialogResult.OK)
                {
                    setDGV();
                }
            }
        }

        private void but_Delete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dgv.SelectedRows)
                {

                    int id = Convert.ToInt32(i.Cells[0].Value.ToString());
                    TTKH_BLL.Instance.delBLL(id);
                }
                MessageBox.Show("Đã xóa thành công  ra khỏi danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Chưa chọn cột muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            setDGV();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            setDGV();
        }

        private void TTKHcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void but_edit_Click_1(object sender, EventArgs e)
        {
            AddEditTTKH addEdit = new AddEditTTKH();
            addEdit.nemdl += AddEdit_nemdl;
            addEdit.ShowDialog();
        }

        private void AddEdit_nemdl(string user_name, string moneyy)
        {
            this.username = user_name;
            this.money = Convert.ToInt32(moneyy);

        }
    }
}
