using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinh_That.DTO;

namespace Chinh_That.DAL
{
    public class PRODUCT_DAL
    {
        private static PRODUCT_DAL instance;
        public static PRODUCT_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PRODUCT_DAL();
                }
                return instance;
            }
            private set { }
        }
        public DataTable getProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("product_name", typeof(String));
            dataTable.Columns.Add("quantity", typeof(int));
            dataTable.Columns.Add("prices", typeof(int));
            dataTable.Columns.Add("image_url", typeof(byte[]));
            dataTable.Columns.Add("id_product_category", typeof(int));
            return dataTable;
        }

        public DataTable getProduct(int id)
        {
            using (QuanLiQuanNetEntities6 db = new  QuanLiQuanNetEntities6())
            {
                var queryResult = db.products.Select(p => new { p.id, p.product_name, p.quantity, p.prices, p.image_url, p.id_product_category }).Where(p => p.id_product_category == id);
                DataTable dataTable = getProduct();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.product_name, result.quantity, result.prices, result.image_url, result.id_product_category);
                }
                return dataTable;
            }
        }

        public DataTable getProductByName(int id, string name)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.products.Select(p => new { p.id, p.product_name, p.quantity, p.prices, p.image_url, p.id_product_category }).Where(p => p.id_product_category == id && p.product_name.Contains(name));
                DataTable dataTable = getProduct();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.product_name, result.quantity, result.prices, result.image_url, result.id_product_category);
                }
                return dataTable;
            }
        }

        public DataTable getProductByID(int id)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.products.Select(p => new { p.id, p.product_name, p.quantity, p.prices, p.image_url, p.id_product_category }).Where(p => p.id == id);
                DataTable dataTable = getProduct();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.product_name, result.quantity, result.prices, result.image_url, result.id_product_category);
                }
                return dataTable;
            }
        }

        
    }
}
