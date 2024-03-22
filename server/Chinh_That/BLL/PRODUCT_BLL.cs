﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinh_That.DAL;

namespace Chinh_That.BLL
{
    public class PRODUCT_BLL
    {
        private static PRODUCT_BLL instance;
        public static PRODUCT_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PRODUCT_BLL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getProductByID(int id)
        {
            return PRODUCT_DAL.Instance.getProduct(id);
        }

        public DataTable getProductByNAME(int id, string name)
        {
            return PRODUCT_DAL.Instance.getProductByName(id, name);
        }

        public DataTable getProductByIDproduct(int ID)
        {
            return PRODUCT_DAL.Instance.getProductByID(ID);
        }
    }
}
