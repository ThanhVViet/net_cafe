using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinh_That.DTO;

namespace Chinh_That.DAL
{
    public class CLIENTDATA_DAL
    {
        private static CLIENTDATA_DAL instance;
        public static CLIENTDATA_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CLIENTDATA_DAL();
                }
                return instance;
            }
            private set { }
        }
        public DataTable createDTUser()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("user_name", typeof(String));
            dataTable.Columns.Add("user_password", typeof(String));
            return dataTable;
        }

        public DataTable createDTCustomer()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("customer_name", typeof(String));
            dataTable.Columns.Add("remaining_time", typeof(String));
            dataTable.Columns.Add("user_name", typeof(String));
            dataTable.Columns.Add("state", typeof(Boolean));
            return dataTable;
        }

        public DataTable createDTUserRole()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("user_name", typeof(String));
            dataTable.Columns.Add("role_name", typeof(String));
            return dataTable;
        }

        public DataTable createDTProduct()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("product_name", typeof(String));
            dataTable.Columns.Add("prices", typeof(int));
            dataTable.Columns.Add("id_product_category", typeof(int));
            //dataTable.Columns.Add("image_url", typeof(String));
            return dataTable;
        }

        public DataTable createDTGame()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("game_category_id", typeof(int));
            dataTable.Columns.Add("game_name", typeof(String));
            dataTable.Columns.Add("played_times", typeof(int));
            dataTable.Columns.Add("path", typeof(String));
            //dataTable.Columns.Add("image_url", typeof(byte[]));
            return dataTable;
        }

        public DataTable createDTNews()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("typee", typeof(String));
            dataTable.Columns.Add("title", typeof(String));
            dataTable.Columns.Add("content", typeof(String));
            dataTable.Columns.Add("create_date", typeof(DateTime));
            //dataTable.Columns.Add("image_url", typeof(byte[]));
            return dataTable;
        }
        public DataTable getAllUser()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                var queryResult = db.users.Select(p => new { p.user_name, p.user_password });
                DataTable dataTable = createDTUser();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.user_name, result.user_password);
                }
                return dataTable;

            }
        }

        public DataTable getAllCustomer()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                var queryResult = db.customers.Select(p => new { p.id, p.customer_name, p.remaining_time, p.user_name, p.state });
                DataTable dataTable = createDTCustomer();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.customer_name, result.remaining_time, result.user_name, result.state);
                }
                return dataTable;

            }
        }

        public DataTable getAllUserRole()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                var queryResult = db.user_role.Select(p => new { p.id, p.user_name, p.role_name });
                DataTable dataTable = createDTUserRole();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.user_name, result.role_name);
                }
                return dataTable;

            }
        }

        public DataTable getAllProduct()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                var queryResult = db.products.Select(p => new { p.id, p.product_name, p.prices, p.id_product_category });
                DataTable dataTable = createDTProduct();

                foreach (var result in queryResult)
                {

                    dataTable.Rows.Add(result.id, result.product_name, result.prices, result.id_product_category);
                }
                return dataTable;

            }
        }
        public DataTable getAllGame()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path });
                DataTable dataTable = createDTGame();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path);
                }
                return dataTable;

            }
        }

        public DataTable getAllNews()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {

                var queryResult = db.news.Select(p => new { p.id, p.typee, p.title, p.content, p.create_date });
                DataTable dataTable = createDTNews();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.typee, result.title, result.content, result.create_date);
                }
                return dataTable;

            }
        }
    }
}
