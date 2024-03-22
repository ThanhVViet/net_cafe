using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chinh_That
{
    public class TTKH_DAL
    {
        private static TTKH_DAL instance;
        public static TTKH_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TTKH_DAL();
                }
                return instance;
            }
            private set
            {

            }
        }
        public List<customer> GetCustomers()
        {
            List<customer> ret = new List<customer>();
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                ret = db.customers.ToList();
            }
            return ret;
        }
        public DataGridView getTTKH()
        {
            DataGridView ttkh = new DataGridView();
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                ttkh.DataSource = db.customers.Select(p => new {
                    p.id,
                    p.user_name,
                    p.remaining_time,
                    p.state
                }).ToList();
            }
            return ttkh;
        }
        public void add_DAL(string user_name, string remaining_time, Boolean state)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                customer cus = new customer();
                cus.user_name = user_name;
                cus.state= state;
                cus.remaining_time = remaining_time;
                db.customers.Add(cus);
                db.SaveChanges();

            }

        }

        public string getRemainingtime(string username)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.customers.Select(p => new { p.id, p.user_name, p.remaining_time, p.state }).Where(p => p.user_name == username).FirstOrDefault();
                return queryResult.remaining_time;
            }
        }
        public void edit_DAL(customer cus)
        {
            // customer cus = new customer();
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                customer cuss = db.customers.Find(cus.id);
                
                //cuss.user_name = cus.user_name;
                cuss.remaining_time = cus.remaining_time;
                db.SaveChanges();
                MessageBox.Show("Đã cập nhật thành công ", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        public void delDAL(int id)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                customer cus = db.customers.Find(id);
                db.customers.Remove(cus);
                db.SaveChanges();
            }
        }
        public DataGridView search_DAL(string search)
        {
            DataGridView dgv = new DataGridView();
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                dgv.DataSource = db.customers.Where
                    (
                        p => p.user_name.ToUpper().Contains(search.ToUpper())
                    )
                    .Select(p => new { p.id, p.user_name, p.remaining_time, p.state }).ToList();
            }
            return dgv;
        }

        public Boolean check_DAL(string username)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                List<String> list = new List<String>();
                var queryResult = db.customers.Select(p => new { p.user_name }).Where(p => p.user_name == username);
                foreach(var Result in queryResult)
                {
                    list.Add(Result.user_name);
                }
                if (list.Count == 0) return false; else return true;
            }
        }

        public Boolean getState(string username)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                Boolean statee = false;
                var queryResult = db.customers.Select(p => new { p.user_name,p.state }).Where(p => p.user_name == username);
                foreach (var Result in queryResult)
                {
                    statee = (Boolean)Result.state;
                }
                return statee;
            }
        }
    }
}
