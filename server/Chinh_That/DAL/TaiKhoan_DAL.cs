using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chinh_That.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chinh_That.DAL
{
    public class TaiKhoan_DAL
    {
        private static TaiKhoan_DAL instance;
        public static TaiKhoan_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoan_DAL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("user_name", typeof(String));
            dataTable.Columns.Add("user_password", typeof(String));
            dataTable.Columns.Add("user_role", typeof(String));
            return dataTable;
        }

        public DataTable getAllAcc()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = from o in db.users
                                  join c in db.user_role on o.user_name equals c.user_name
                                  select new { user_name = o.user_name, user_password = o.user_password, role_name = c.role_name };


                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.user_name, result.user_password, result.role_name);
                }
                return dataTable;
            }
        }

        public void add_DAL(user ne)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.users.Add(ne);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void addRole_DAL(user_role ne)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.user_role.Add(ne);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public List<user> load()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<user> ns = db.users.ToList();
            return ns;
        }
        public void del_DAL(String user_name)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                user cus = db.users.Find(user_name);
                db.users.Remove(cus);
                db.SaveChanges();
            }
        }

        public int getUserRoleID(String username)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.user_role.Select(p => new { p.id, p.user_name, p.role_name }).Where(p => p.user_name == username).FirstOrDefault();
                int cs = queryResult.id;
                return cs;
            }
        }

        public void update_DAL(String user_name, user ne, user_role ur)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                user cus = db.users.Find(ne.user_name);
                cus.user_password = ne.user_password;
                user_role usr = db.user_role.Find(TaiKhoan_DAL.Instance.getUserRoleID(ne.user_name));
                usr.role_name = ur.role_name;
                db.SaveChanges();
                MessageBox.Show("Cập nhật tài khoản thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
