using Chinh_That.DTO;
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
    public partial class Addnews : Form
    {
        public Addnews()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                open.Filter = "(*.jpg;*.jpeg;*.bmp)|*.jpg;*.jpeg;*.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);

                }

            }
        }

        private void but_save_Click(object sender, EventArgs e)
        {

            news ne = new news();
         //   ne.typee = txt_type.Text;
            ne.title = txt_title.Text;
            ne.content = txt_content.Text;
            ne.create_date = dateTimePicker1.Value;
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] NVpic = ms.GetBuffer();
            ms.Close();
            ne.image_url = NVpic;
            news_BLL.Instance.add_BLL(ne);

            
        }
    }
}
