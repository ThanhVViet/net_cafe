using Chinh_That.DAL;
using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinh_That.BLL
{
    internal class Menu_BLL
    {
        private static Menu_BLL instance;
        public static Menu_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Menu_BLL();
                }
                return instance;
            }
        }
        public List<product> getMenu()
        {
           return Menu_DAL.Instance.getMenu();
        }
    }
}
