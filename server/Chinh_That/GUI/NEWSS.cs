using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chinh_That.DTO;

namespace Chinh_That
{
    public partial class NEWSS : Form
    {
        public NEWSS()
        {
            InitializeComponent();
        }

        private void NEWSS_Load(object sender, EventArgs e)
        {
            load();
        }

        private void but_add_Click(object sender, EventArgs e)
        {
            Addnews addnews = new Addnews();

            if (addnews.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                load();
            }
        }
        public void load()
        {
            List<news> news = news_BLL.Instance.showflp();
            foreach (news item in news)
            {
                UserControlItem item2 = new UserControlItem(item.typee ,item.title, item.content, (DateTime)item.create_date, (byte[])item.image_url, (int)item.id);
                flowLayoutPanel1.Controls.Add(item2);

            }

        }
    }
}
