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

namespace Chinh_That
{
    public partial class QLGAME : Form
    {
        public QLGAME()
        {
            InitializeComponent();
        }

        private void but_add_Click(object sender, EventArgs e)
        {
            Addgame addgame = new Addgame(0);

            if (addgame.ShowDialog() == DialogResult.OK)
            {
                
                load();

            }
        }
        public void load()
        {
            DataTable dt = new DataTable();
            dt = GAME_BLL.Instance.getAllGameByType();
            dataGridView1.DataSource = dt;
        }

        private void QLGAME_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0) {
                MessageBox.Show("Bạn chưa chọn hàng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Addgame ag = new Addgame(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString()), dataGridView1.CurrentRow.Cells["game_category_name"].Value.ToString(), dataGridView1.CurrentRow.Cells["game_name"].Value.ToString(),Convert.ToInt32(dataGridView1.CurrentRow.Cells["played_times"].Value.ToString()), dataGridView1.CurrentRow.Cells["path"].Value.ToString(), (byte[])dataGridView1.CurrentRow.Cells["image_url"].Value,1) ;
                if (ag.ShowDialog() == DialogResult.OK)
                {

                    load();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Bạn chưa chọn hàng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GAME_BLL.Instance.del_BLL(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load();
            }
        }
    }
}
