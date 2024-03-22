using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Chinh_That.BLL;

namespace Chinh_That
{
    public partial class Home : Form
    {
        public Home(String role)
        {
            InitializeComponent();
            this.role_name = role;
            Control.CheckForIllegalCrossThreadCalls = false;
            rrmt = new RECEIVERMTIME();
            ttkh = new TTKHcs();
            ttkh.but_edit.Click += But_edit_Click;
        }
        private String role_name = "";
        
        private void But_edit_Click(object sender, EventArgs e)
        {
            AddEditTTKH addEdit = new AddEditTTKH();
            addEdit.nemdl += AddEdit_nemdl;
            addEdit.ShowDialog();
        }

        private void AddEdit_nemdl(string user_name, string money)
        {
            int phut = ((Convert.ToInt32(money)) * 10)/1000;
            String time = (phut / 60).ToString() + ":" + (phut % 60).ToString();
            if (!TTKH_BLL.Instance.getStateByUsername(user_name))
            {
                String[] str = TTKH_BLL.Instance.getRMTimeByName(user_name).Split(':');
                String[] str2 = time.Split(':');
                int Hour1 = Convert.ToInt32(str[0]);
                int Hour2 = Convert.ToInt32(str2[0]);
                int Minute1 = Convert.ToInt32(str[1]);
                int Minute2 = Convert.ToInt32(str2[1]);
                if (Minute1 + Minute2 >= 60)
                {
                    Hour1 += Hour2 + 1;
                    Minute1 = (Minute1 + Minute2) - 60;
                }
                else
                {
                    Hour1 += Hour2;
                    Minute1 += Minute2;
                }
                string NewRMTime = Hour1.ToString() + ":" + Minute1.ToString() + ":" + str[2];
                int id = ACCOUNT_BLL.Instance.getAccountID(user_name);
                ACCOUNT_BLL.Instance.updateReminingtime(id, NewRMTime);
            }
            else rrmt.Send(user_name, time);
        }

        private Form activeForm = null;
        private TTKHcs ttkh;
        private RECEIVERMTIME rrmt;
        private void openChildFormInPanel(Form childForm)
        {
            
                if (activeForm != null)
                    activeForm.Close();
                activeForm = childForm;

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                pContainer.Controls.Clear();
                pContainer.Controls.Add(childForm);
                pContainer.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();

        }
    
        private void btnNV_Click(object sender, EventArgs e)
        {
            if (this.role_name == "staff")
            {
                MessageBox.Show("Nhân viên không thể sử dụng chức năng này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else openChildFormInPanel(new DSNV());
        }
        private int imageNumber = 1;
        private void LoadNextImage()
        {
            if (imageNumber == 5)
            {
                imageNumber = 1;
            }
         //   slidePic.ImageLocation = string.Format(@"Images\{0}.jpg", imageNumber);
            imageNumber++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void btnCa_Click(object sender, EventArgs e)
        {
            if (this.role_name == "staff")
            {
                MessageBox.Show("Nhân viên không thể sử dụng chức năng này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else openChildFormInPanel(new DSC());
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new DSDV());
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new DSCom());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ttkh.TopLevel = false;
            ttkh.FormBorderStyle = FormBorderStyle.None;
            ttkh.Dock = DockStyle.Fill;
            pContainer.Controls.Clear();
            pContainer.Controls.Add(ttkh);
            pContainer.Tag = ttkh;
            ttkh.BringToFront();
            ttkh.Show();
        }

        private void btnNEWS_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new NEWSS());
        }

        private void rjButton3_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new QLGAME());
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new QLTAIKHOAN(role_name));
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            rrmt.Dispose();
        }
    }
}
