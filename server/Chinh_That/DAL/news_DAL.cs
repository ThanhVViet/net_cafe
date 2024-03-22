using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinh_That
{
    public class news_DAL
    {
        private static news_DAL instance;
        public static news_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new news_DAL();
                }
                return instance;
            }
            private set { }
        }
        public List<news> GetNews()
        {
            List<news> ret = new List<news>();
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                ret = db.news.ToList();
            }
            return ret;
        }
        public void add_DAL(news ne)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.news.Add(ne);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public List<news> load()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<news> ns = db.news.ToList();
            return ns;
        }
        public void del_DAL(int id)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                news cus = db.news.Find(id);
                db.news.Remove(cus);
                db.SaveChanges();
            }
        }


    }
}
