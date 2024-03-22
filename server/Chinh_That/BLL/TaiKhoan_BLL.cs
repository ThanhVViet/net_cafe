using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinh_That.DAL;
using Chinh_That.DTO;

namespace Chinh_That.BLL
{
    public class TaiKhoan_BLL
    {
        private static TaiKhoan_BLL instance;
        public static TaiKhoan_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoan_BLL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getAllTK()
        {
            return TaiKhoan_DAL.Instance.getAllAcc();
        }

        public void add_BLL(user ne)
        {
            TaiKhoan_DAL.Instance.add_DAL(ne);
        }

        public void addRole_BLL(user_role ne)
        {
            TaiKhoan_DAL.Instance.addRole_DAL(ne);
        }
        public List<user> showflp()
        {
            return TaiKhoan_DAL.Instance.load();
        }
        public void del_BLL(String user_name)
        {
            TaiKhoan_DAL.Instance.del_DAL(user_name);
        }

        public int getUserRoleID(String username)
        {
            return TaiKhoan_DAL.Instance.getUserRoleID(username);
        }
        public void update_BLL(String user_name, user ne, user_role ur)
        {
            TaiKhoan_DAL.Instance.update_DAL(user_name, ne, ur);
        }
    }
}
