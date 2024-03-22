using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinh_That.DAL;

namespace Chinh_That.BLL
{
    public class CLIENTDATA_BLL
    {
        private static CLIENTDATA_BLL instance;
        public static CLIENTDATA_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CLIENTDATA_BLL();
                }
                return instance;
            }
            private set { }
        }
        public DataTable getAllUser()
        {
            return CLIENTDATA_DAL.Instance.getAllUser();
        }

        public DataTable getAllCustomer()
        {
            return CLIENTDATA_DAL.Instance.getAllCustomer();
        }

        public DataTable getAllUserRole()
        {
            return CLIENTDATA_DAL.Instance.getAllUserRole();
        }

        public DataTable getAllProduct()
        {
            return CLIENTDATA_DAL.Instance.getAllProduct();
        }

        public DataTable getAllGame()
        {
            return CLIENTDATA_DAL.Instance.getAllGame();
        }

        public DataTable getAllNews()
        {
            return CLIENTDATA_DAL.Instance.getAllNews();
        }
    }
}
