using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chinh_That.BLL;
using Chinh_That.DTO;

namespace Chinh_That
{
    public partial class SaleProduct : Form
    {
        public SaleProduct(int payment_id)
        {
            InitializeComponent();
            this.payment_id = payment_id;
        
        }
        int payment_id = 0;
        
        private void SaleProduct_Load(object sender, EventArgs e)
        {       
            List<payment_detail> payment = DichVu_BLL.Instance.GetPayment_Details(payment_id);
            foreach (payment_detail pm in payment)
            {
               
                product pd = DichVu_BLL.Instance.GetProductById(Convert.ToInt32(pm.product_id));
       
                if (pd != null)
                {
                    SaleItemsGridView.Rows.Add(pd.product_name, pd.prices, pm.product_quantity, pm.total);
                }
            }
        }
    }
}
