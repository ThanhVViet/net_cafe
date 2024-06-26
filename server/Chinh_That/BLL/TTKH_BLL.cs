﻿using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinh_That
{
    public class TTKH_BLL
    {
        private static TTKH_BLL instance;
        public static TTKH_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TTKH_BLL();
                }
                return instance;
            }
            private set { }
        }
        public DataGridView showdgv()
        {
            return TTKH_DAL.Instance.getTTKH();
        }
        public void delBLL(int id)
        {
            TTKH_DAL.Instance.delDAL(id);
        }
        public void add_BLL(string user_name, string remaining_time, Boolean state)
        {
            TTKH_DAL.Instance.add_DAL(user_name, remaining_time, state);
        }
        public void edit_BLL(customer id)
        {
            TTKH_DAL.Instance.edit_DAL(id);
        }
        
        public Boolean getStateByUsername(String username)
        {
            return TTKH_DAL.Instance.getState(username);
        }
        public Boolean check_BLL(String username)
        {
            return TTKH_DAL.Instance.check_DAL(username);
        }
        public customer GetCustomerByID(int id)
        {
            foreach (customer i in TTKH_DAL.Instance.GetCustomers())
            {
                if (i.id == id) return i;
            }
            return null;
        }
        public customer GetCustomerByName(string user_name)
        {
            foreach (customer i in TTKH_DAL.Instance.GetCustomers())
            {
                if (i.user_name == user_name) return i;
            }
            return null;
        }

        public string getRMTimeByName(string user_name)
        {
            return TTKH_DAL.Instance.getRemainingtime(user_name);
        }

        public DataGridView search_BLL(string search)
        {
            DataGridView dgv = new DataGridView();
            dgv.DataSource = TTKH_DAL.Instance.search_DAL(search).DataSource;
            return dgv;
        }
    }
}
