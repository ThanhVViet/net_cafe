using Chinh_That.DAL;
using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Chinh_That.BLL
{
    internal class DichVu_BLL
    {
        private static DichVu_BLL instance;
        public static DichVu_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DichVu_BLL();
                }
                return instance;
            }
        }
        public void delCY()
        {
            DichVu_DAL.Instance.delCY();
        }
        public void addCY (category cy)
        {
            DichVu_DAL.Instance.addCY(cy);
        }
        public void editCY(category cy)
        {
            DichVu_DAL.Instance.editCY(cy);
        }
        public void delP()
        {
            DichVu_DAL.Instance.delP();
        }
        public void addP(product p)
        {
            DichVu_DAL.Instance.addP(p);
        }
        public List<category> getCategories()
        {
            return DichVu_DAL.Instance.getCY();
        }
        public List<product> getProducts(int idCY)
        {
            return DichVu_DAL.Instance.GetProducts(idCY);
        }
        public product showP(int idP)
        {
           return DichVu_DAL.Instance.showProducts(idP);
        }
        public List<product> getProducts()
        {
            return DichVu_DAL.Instance.GetProducts();
        }
        public category getCategoryById(int id)
        {
            return DichVu_DAL.Instance.getCategoryById(id);
        }
        public List<CBBItem> getCBB()
        {
            List<CBBItem > list = new List<CBBItem>();
            foreach(category cy in getCategories())
            {
                CBBItem item = new CBBItem()
                {
                    Value = cy.id,
                    Text = cy.product_category_name
                };
                list.Add(item);
            }
            return list;
        }
        public void getSale(payment pay, List<payment_detail> details)
        {
            DichVu_DAL.Instance.RecordSale( pay, details);
        }

        public category getCategoryByCategoryName(string categoryName)
        {
            return DichVu_DAL.Instance.getCategoryByCategoryName(categoryName);
        }
        public List<product> getProductsByCategoryId(int id)
        {
            return DichVu_DAL.Instance.getProductsByCategoryId(id);
        }
        public List<payment> GetPayment()
        {
            return DichVu_DAL.Instance.GetPayment();
        }
        public void editP(product p)
        {
            DichVu_DAL.Instance.editP(p);  
        }
        public List<payment_detail> GetPayment_Details(int payment_id)
        {
            return DichVu_DAL.Instance.GetPayment_Detail(payment_id);
        }
        public product GetProductById(int id)
        {
            foreach (product p in DichVu_DAL.Instance.GetProducts())
            {
                if (p.id == id) 
                    return p;
            }
            return null;
        }
    }
}
