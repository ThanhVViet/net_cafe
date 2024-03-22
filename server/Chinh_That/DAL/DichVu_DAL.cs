using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Chinh_That.DAL
{
    internal class DichVu_DAL
    {
        private static DichVu_DAL instance;
        public static DichVu_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DichVu_DAL();
                }
                return instance;
            }
            private set { }
        }
        public void delCY()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {              
                var del = db.categories
                    .Include(p => p.products.Select(t => t.payment_detail))
                        .FirstOrDefault();
                db.categories.Remove(del);
                List<product> products = db.products.ToList();
                foreach(product pd in products)
                {
                    var del1 = db.products
                    .Include(p => p.payment_detail)
                        .FirstOrDefault();
                    db.products.Remove(del1);
                    db.SaveChanges();
                }
                db.SaveChanges();             
            }
        }
        public void addCY(category cy)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.categories.Add(cy);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công loại mới !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void editCY(category category)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                int cs = Convert.ToInt32(category.id);
                category cy = new category();
                cy = db.categories.Find(cs);
                cy.product_category_name = category.product_category_name;
                cy.image_category = category.image_category;
                db.SaveChanges();
                MessageBox.Show("Đã cập nhật thành công thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void delP()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var del = db.products
                    .Include(p => p.payment_detail)
                        .FirstOrDefault();
                db.products.Remove(del);
                db.SaveChanges();
            }
        }
        public void addP(product p)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.products.Add(p);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công sản phẩm mới !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void editP(product p)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            product bf = db.products.Find(p.id);
            bf.product_name = p.product_name;
            bf.prices = p.prices;
            bf.id_product_category = p.id_product_category;
            bf.image_url = p.image_url;
            db.SaveChanges();
        }
        public List<category> getCY()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<category> categories = db.categories.ToList();
            return categories;
        } 
        public List<product> GetProducts(int idCY)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<product> products = db.products.Where(p => p.id_product_category == idCY).ToList();
            return products;
        }
        public product showProducts(int idP)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            product product = db.products.Where(p => p.id == idP).FirstOrDefault();
            return product;
        }      
        public List<product> GetProducts()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<product> products = db.products.ToList();
            return products;
        }
        public category getCategoryById(int id)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            category category = db.categories.Where(p => p.id == id).FirstOrDefault();
            return category;
        }
        public void RecordSale(payment pay, List<payment_detail> details)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            db.payments.Add(pay);
            db.SaveChanges();
            foreach (payment_detail detail in details)
            {
                QuanLiQuanNetEntities6 db1 = new QuanLiQuanNetEntities6();
                detail.payment_id = pay.id;
                db1.payment_detail.Add(detail);
                db1.SaveChanges();
            }
        }

        public category getCategoryByCategoryName(string categoryName)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            category category = db.categories.Where(p => p.product_category_name == categoryName).FirstOrDefault();
            return category;
        }
        public List<product> getProductsByCategoryId(int id)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<product> products = db.products.Where(p => p.id_product_category == id).ToList();
            return products;
        }
        public List<payment> GetPayment()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<payment> payments = db.payments.ToList();
            return payments;
        }
        public List<payment_detail> GetPayment_Detail(int payment_id)
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<payment_detail> payment = db.payment_detail.Where(p => p.payment_id == payment_id).ToList();
            return payment;
        }

    }
}
