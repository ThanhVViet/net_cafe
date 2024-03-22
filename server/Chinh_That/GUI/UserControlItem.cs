using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinh_That
{
    public partial class UserControlItem : UserControl
    {
        public UserControlItem()
        {
            InitializeComponent();
        }
        public UserControlItem(string typee, string title, string content, DateTime time, byte[] image, int id)
        {
            InitializeComponent();
            lab_type.Text = typee;
            lab_title.Text = title;
            lab_Content.Text = content;
            lab_time.Text = time.ToShortDateString();
            if (image != null)
            {
                MemoryStream ms = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(ms);
            }
            lbID.Text = id.ToString();

        }

        private void but_delete_Click(object sender, EventArgs e)
        {
            int cs = Convert.ToInt32(lbID.Text);
            news_BLL.Instance.del_BLL(cs);
            MessageBox.Show("bạn có muốn xóa không");
            this.Dispose();
        }

        
    }
}
