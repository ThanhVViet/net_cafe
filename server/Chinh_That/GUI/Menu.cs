using Chinh_That.BLL;
using Chinh_That.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinh_That
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Retrieve();
        }
        public void Retrieve()
        {
            List<product> products = Menu_BLL.Instance.getMenu();
            foreach (product product in products)
            {
                UserControl_P us = new UserControl_P(
                    product.product_name,
                    product.image_url,
                    product.id,
                   (Int32)product.prices
                    );
                FLP.Controls.Add(us);

            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                FLP.Controls.Clear();
                Retrieve();
            }

            else if (comboBox1.SelectedIndex > 0)
            {
                FLP.Controls.Clear();
                string CategoryName = comboBox1.SelectedItem.ToString();
                category category = DichVu_BLL.Instance.getCategoryByCategoryName(CategoryName);
                int CategoryID = category.id;
                List<product> products = DichVu_BLL.Instance.getProductsByCategoryId(CategoryID);
                foreach (product product in products)
                {
                    UserControl_P us = new UserControl_P(
                    product.product_name,
                    product.image_url,
                    product.id,
                   (Int32)product.prices
                    );
                    FLP.Controls.Add(us);
                }

            }
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            List<category> categories = DichVu_BLL.Instance.getCategories();
            comboBox1.Items.Add("All Categories");
            foreach (category c in categories)
            {
                comboBox1.Items.Add(c.product_category_name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
