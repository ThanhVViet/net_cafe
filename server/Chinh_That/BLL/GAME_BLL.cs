using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinh_That.DAL;
using Chinh_That.DTO;

namespace Chinh_That.BLL
{
    public class GAME_BLL
    {
        private static GAME_BLL instance;
        public static GAME_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GAME_BLL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getGameByID(int id)
        {
            return GAME_DAL.Instance.getGame(id);
        }

        public DataTable getAllGAME()
        {
            return GAME_DAL.Instance.getAllGame();
        }

        public DataTable getGameByNAME(int id, string name)
        {
            return GAME_DAL.Instance.getGameByName(id, name);
        }
        public DataTable getAllGameByNAME(string name)
        {
            return GAME_DAL.Instance.getAllGameByName(name);
        }
        public game GetGameByID(int id)
        {
            foreach (game i in GAME_DAL.Instance.GetGame())
            {
                if (i.id == id) return i;
            }
            return null;
        }
        public DataTable getAllGameByType()
        {
            return GAME_DAL.Instance.getAllGameByType();
        }

        public int getGameID(string gamename)
        {
            return GAME_DAL.Instance.getIDgame(gamename);
        }

        public void updatePlayedTime(int id)
        {
            GAME_DAL.Instance.updatePlayedTime(id);
        }
        public void add_BLL(game ne)
        {
            GAME_DAL.Instance.add_DAL(ne);
        }
        public List<game> showflp()
        {
            return GAME_DAL.Instance.load();
        }
        public void del_BLL(int id)
        {
            GAME_DAL.Instance.del_DAL(id);
        }

        public void update_BLL(int id, game ne)
        {
            GAME_DAL.Instance.update_DAL(id,ne);
        }
    }
}
