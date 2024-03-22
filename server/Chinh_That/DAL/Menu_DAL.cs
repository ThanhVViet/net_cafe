using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinh_That.DAL
{
    internal class Menu_DAL
    {
        private static Menu_DAL instance;
        public static Menu_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Menu_DAL();
                }
                return instance;
            }
            private set { }
        }
        public List<product> getMenu()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<product> products = db.products.ToList();
            return products;
        }
    }
}
