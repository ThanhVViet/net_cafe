using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Chinh_That.DTO;
using Chinh_That.BLL;

namespace Chinh_That
{
    public partial class UserControlDays : UserControl
    {
       
        private int Day, Month, Year;
        private void UserControlDays_Click(object sender, EventArgs e)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            Detail f = new Detail(Day, Month, Year);         
            f.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {       
            fCA k = new fCA(0, Day, Month, Year);
            if(k.ShowDialog() == DialogResult.OK)
            {             
                display();
            }
        }
        
        public UserControlDays(int day, int month, int year)
        {
            InitializeComponent();
            Day = day;
            Month = month;
            Year = year;
            labelDay.Text = Day + "";
            highlightToday();
        }
        private void UserControlDays_Load(object sender, EventArgs e)
        {
            display();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {        
            List<worktime> worktimes = CaLam_BLL.Instance.getCa(new DateTime(Year, Month, Day));
            int numapp = worktimes.Count;
            lbNum.Text = numapp.ToString();
            if (worktimes.Count > 0)
            {
                labelDay.BackColor = Color.HotPink;
            }
            else
            {
                this.BackColor = Color.Black;
                labelDay.BackColor = Color.FromArgb(25, 26, 57);
            }
        }
        private void highlightToday()
        {
            DateTime now = DateTime.Now;
            if (Day == now.Day && Month == now.Month && Year == now.Year)
            {
                labelDay.ForeColor = Color.FromArgb(0, 202, 99);
            }
        }
    }
}
