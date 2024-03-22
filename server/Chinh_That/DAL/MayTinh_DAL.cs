using Chinh_That.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Chinh_That.DAL
{
    internal class MayTinh_DAL
    {
        private static MayTinh_DAL instance;
        public static MayTinh_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MayTinh_DAL();
                }
                return instance;
            }
            private set { }
        }

        public List<computer> getAllCom()
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                List<computer> computers = new List<computer>();
                var queryResult = db.computers.Select(p => new { p.id, p.active_status, p.ip, p.num_com, p.manufacturer, p.warranty, p.user_name }).OrderBy(p => p.num_com);
                foreach (var result in queryResult)
                {
                    computer cp = new computer();
                    cp.id = result.id;
                    cp.active_status= result.active_status;
                    cp.ip = result.ip;
                    cp.num_com = result.num_com;
                    cp.manufacturer = result.manufacturer;
                    cp.warranty= result.warranty;
                    cp.user_name= result.user_name;
                    computers.Add(cp);
                }
                
                return computers;
            }
        }
        public void delCom(int idCom)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                computer com = db.computers.Find(idCom);
                db.computers.Remove(com);
                db.SaveChanges();
            }
        }
        public void addCom(computer com)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                db.computers.Add(com);
                db.SaveChanges();
                MessageBox.Show("Đã thêm thành công máy mới !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void editCom(computer computer)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                int cs = Convert.ToInt32(computer.id);
                computer cp = new computer();
                cp = db.computers.Find(cs);
                cp.num_com = computer.num_com;
                cp.ip = computer.ip;
                cp.manufacturer = computer.manufacturer;
                cp.warranty = computer.warranty;
                db.SaveChanges();
                MessageBox.Show("Đã cập nhật thành công thông tin của máy !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public int getComByIP(String IP)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.computers.Select(p => new { p.id, p.active_status, p.ip, p.num_com, p.manufacturer, p.warranty }).Where(p => p.ip == IP).FirstOrDefault();
                return Convert.ToInt32(queryResult.num_com);
            }
        }

        public int getIDByIP(String IP)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                var queryResult = db.computers.Select(p => new { p.id, p.active_status, p.ip, p.num_com, p.manufacturer, p.warranty }).Where(p => p.ip == IP).FirstOrDefault();
                return queryResult.id;
            }
        }

        public void updateStatus(int ID,Boolean status)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                computer cp = db.computers.Find(ID);
                cp.active_status = status;
                db.SaveChanges();
            }
        }

        public void updateUser(int ID, String username)
        {
            using (QuanLiQuanNetEntities6 db = new QuanLiQuanNetEntities6())
            {
                computer cp = db.computers.Find(ID);
                cp.user_name = username;
                db.SaveChanges();
            }
        }
    }
}
