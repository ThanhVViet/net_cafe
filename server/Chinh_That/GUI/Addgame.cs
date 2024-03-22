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
using Chinh_That.BLL;
using Chinh_That.DTO;

namespace Chinh_That
{
    public partial class Addgame : Form
    {
        public Addgame()
        {
            InitializeComponent();
        }
        int ID;
        public Addgame(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        public Addgame(int lbID1,String gci,string gn,int pt,string path,byte[] image,int ID)
        {
            InitializeComponent();
            lbID.Text = lbID1.ToString();
            textBox1.SelectedItem = gci.ToString();
            textBox2.Text = gn;
            textBox3.Text = pt.ToString();
            textBox4.Text = path;
            //pictureBox1.Image = image;
            MemoryStream ms = new MemoryStream(image);
            pictureBox1.Image = Image.FromStream(ms);
            this.ID = ID;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                try
                {
                    textBox4.Text = System.IO.Path.GetFullPath(fileName);
                }
                catch (System.Exception)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chon anh";
            openFileDialog.Filter = "Image Files(*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                game ge = new game();
                int id = 0;
                if (textBox1.SelectedItem == "offline") id = 1; 
                else if (textBox1.SelectedItem == "online") id = 2;
                else if (textBox1.SelectedItem == "tools") id = 3;
                ge.game_category_id = id;
                ge.game_name = textBox2.Text;
                ge.played_times = Convert.ToInt32(textBox3.Text);
                ge.path = textBox4.Text;
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] NVpic = ms.GetBuffer();
                ms.Close();
                ge.image_url = NVpic;
                GAME_BLL.Instance.add_BLL(ge);
            }
            else if (ID == 1)
            {
                game ge = new game();
                ge.id = Convert.ToInt32(lbID.Text);
                int id = 0;
                if (textBox1.SelectedItem == "offline") id = 1;
                else if (textBox1.SelectedItem == "online") id = 2;
                else if (textBox1.SelectedItem == "tools") id = 3;
                ge.game_category_id = id;
                ge.game_name = textBox2.Text;
                ge.played_times = Convert.ToInt32(textBox3.Text);
                ge.path = textBox4.Text;
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] NVpic = ms.GetBuffer();
                ms.Close();
                ge.image_url = NVpic;
                GAME_BLL.Instance.update_BLL(Convert.ToInt32(lbID.Text), ge);
            }
        }
    }
}
