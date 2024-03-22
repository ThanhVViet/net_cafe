using Chinh_That.DAL;
using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinh_That.BLL
{
    internal class MayTinh_BLL
    {
        private static MayTinh_BLL instance;
        public static MayTinh_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MayTinh_BLL();
                }
                return instance;
            }
        }
        public void delCom(int idCom)
        {
            MayTinh_DAL.Instance.delCom(idCom);
        }
        public void addCom(computer com)
        {
            MayTinh_DAL.Instance.addCom(com);
        }
        public void editCom(computer com)
        {
            MayTinh_DAL.Instance.editCom(com);
        }

        public int getComByIP(String IP)
        {
            return MayTinh_DAL.Instance.getComByIP(IP);
        }

        public int getIDByIP(String IP)
        {
            return MayTinh_DAL.Instance.getIDByIP(IP);
        }

        public void UpdateStatus(int ID,Boolean status)
        {
            MayTinh_DAL.Instance.updateStatus(ID,status);
        }

        public void UpdateUser(int ID, String username)
        {
            MayTinh_DAL.Instance.updateUser(ID,username);
        }

        public List<computer> getAllComputer()
        {
            return MayTinh_DAL.Instance.getAllCom();
        }
    }
}
