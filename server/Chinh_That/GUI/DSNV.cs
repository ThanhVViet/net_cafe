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
    public partial class DSNV : Form
    {
    
        public DSNV()
        {
            InitializeComponent();
        }

        private void txtFind__TextChanged(object sender, EventArgs e)
        {
            FLP.Controls.Clear();
            if (txtFind.Text == "")
            {
                Retrieve();
                return;
            }
            else
            {          
                List<employee> employees = NhanVien_BLL.Instance.searchNV(txtFind.Text, txtFind.Text);
                foreach (employee nv in employees)
                {
                    UserControl_NV us = new UserControl_NV(nv.id, nv.employee_name, nv.phone, (DateTime)nv.date_of_birth, nv.image_nv, nv.email);
                    FLP.Controls.Add(us);
                }
            }
        }

        private void DSNV_Load(object sender, EventArgs e)
        {
            Retrieve();
        }
        public void Retrieve()
        {
            List<employee> employees = NhanVien_BLL.Instance.listNV();

            foreach (employee nv in employees)
            {
                UserControl_NV us = new UserControl_NV(nv.id, nv.employee_name, nv.phone, (DateTime)nv.date_of_birth, nv.image_nv, nv.email);
                FLP.Controls.Add(us);
            }

        }
        private void btnAddNV_Click(object sender, EventArgs e)
        {
            fNV k = new fNV(0);
           // k.nemdl += K_nemdl;
          if(  k.ShowDialog() == DialogResult.OK)
            {
                FLP.Controls.Clear();
                Retrieve();
            }    
        }
        private void K_nemdl(employee e)
        {
            UserControl_NV us = new UserControl_NV(e.id, e.employee_name, e.phone, (DateTime)e.date_of_birth, e.image_nv,e.email);
            FLP.Controls.Add(us);
        }
    }
}
