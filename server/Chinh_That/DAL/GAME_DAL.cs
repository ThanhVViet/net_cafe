using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Chinh_That.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chinh_That.DAL
{
    public class GAME_DAL
    {
        private static GAME_DAL instance;
        public static GAME_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GAME_DAL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("game_category_id", typeof(int));
            dataTable.Columns.Add("game_name", typeof(String));
            dataTable.Columns.Add("played_times", typeof(int));
            dataTable.Columns.Add("path", typeof(String));
            dataTable.Columns.Add("image_url", typeof(byte[]));
            return dataTable;
        }

        public DataTable createDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("game_category_name", typeof(String));
            dataTable.Columns.Add("game_name", typeof(String));
            dataTable.Columns.Add("played_times", typeof(int));
            dataTable.Columns.Add("path", typeof(String));
            dataTable.Columns.Add("image_url", typeof(byte[]));
            return dataTable;
        }

        public DataTable getGame(int id)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_category_id == id).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getGameByName(int id, string name)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_category_id == id && p.game_name.Contains(name)).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getAllGame()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getAllGameByName(string name)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_name.Contains(name)).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getAllGameByType()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = from o in db.games
                                  join c in db.game_category on o.game_category_id equals c.id
                                  select new { id = o.id , game_category_name = c.game_category_name, game_name = o.game_name, played_times = o.played_times, path = o.path, image_url = o.image_url };


                DataTable dataTable = createDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id,result.game_category_name,result.game_name,result.played_times,result.path,result.image_url);
                }
                return dataTable;
            }
        }

        public int getIDgame(String game_name)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_name == game_name).FirstOrDefault();
                int id = queryResult.id;
                return id;
            }
        }

        public void updatePlayedTime(int id)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                game cus = db.games.Find(id);
                cus.played_times += 1;
                db.SaveChanges();
            }
        }

        public List<game> GetGame()
        {
            List<game> ret = new List<game>();
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                ret = db.games.ToList();
            }
            return ret;
        }
        public void add_DAL(game ne)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.games.Add(ne);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public List<game> load()
        {
            QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6();
            List<game> ns = db.games.ToList();
            return ns;
        }
        public void del_DAL(int id)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                game cus = db.games.Find(id);
                db.games.Remove(cus);
                db.SaveChanges();
            }
        }

        public void update_DAL(int id,game ne)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                game cus = db.games.Find(ne.id);
                cus.game_category_id = ne.game_category_id;
                cus.game_name = ne.game_name;
                cus.played_times = ne.played_times;
                cus.path = ne.path;
                cus.image_url = ne.image_url;
                db.SaveChanges();
                MessageBox.Show("Đã cập nhật thành công ", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
