using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using Chinh_That.DTO;
using Chinh_That.BLL;

namespace Chinh_That
{
    public partial class DSCom : Form
    {
        QuanLiQuanNetEntities6 db;
        public DSCom()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void btnAdd_Com_Click(object sender, EventArgs e)
        {
            db = new QuanLiQuanNetEntities6();
            fCOM fc = new fCOM(0);              
            fc.nemdl += K_nemdl;
            fc.ShowDialog();
            
        }
        public void Retrieve()
        {

            List<computer> computers = MayTinh_BLL.Instance.getAllComputer();
            foreach (computer cp in computers)
            {
                UserControl_COM us = new UserControl_COM(
                    cp.num_com.ToString(), cp.id,cp.manufacturer,cp.warranty,cp.ip, (Boolean)cp.active_status, cp.user_name.ToString());
                FLPCom.Controls.Add(us);
            }
        }
        private void K_nemdl(computer w)
        {
            UserControl_COM us = new UserControl_COM(w.num_com.ToString(),w.id, w.manufacturer, w.warranty,w.ip.ToString(), (Boolean)w.active_status,w.user_name.ToString());
            FLPCom.Controls.Add(us);
        }

        private void DSCom_Load(object sender, EventArgs e)
        {
            Retrieve();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Retrieve();
        }

        private void DSCom_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
