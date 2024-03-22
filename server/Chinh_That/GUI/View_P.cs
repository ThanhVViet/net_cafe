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
    public partial class View_P : Form
    {
       
        public View_P()
        {
            InitializeComponent();
          
        }
        private void View_P_Load(object sender, EventArgs e)
        {
            List<category> categories = DichVu_BLL.Instance.getCategories();
            cbbProductCategory.Items.Add("All Categories");
            foreach (category c in categories)
            {
                cbbProductCategory.Items.Add(c.product_category_name);
            }
            cbbProductCategory.SelectedIndex = 0;
        }

        private void ProductCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dgvProducts.Rows.Clear();

            if (cbbProductCategory.SelectedIndex == 0)
            { 
                List<product> products = DichVu_BLL.Instance.getProducts();
                foreach (product product in products)
                {       
                    category category = DichVu_BLL.Instance.getCategoryById(Convert.ToInt32(product.id_product_category));
                    dgvProducts.Rows.Add(product.id, product.product_name, product.prices, category.product_category_name, product.image_url);
                }
            }

            else if (cbbProductCategory.SelectedIndex > 0)
            {
                string CategoryName = cbbProductCategory.SelectedItem.ToString();
                category category = DichVu_BLL.Instance.getCategoryByCategoryName(CategoryName);
                int CategoryID = category.id;
                List<product> products = DichVu_BLL.Instance.getProductsByCategoryId(CategoryID);
                foreach (product product in products)
                {
                    dgvProducts.Rows.Add(product.id, product.product_name, product.prices, category.product_category_name, product.image_url);
                }

            }

        }
        private void ProductsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvProducts.Columns[e.ColumnIndex].Name == "DeleteProductColumn")
                {
                    if (MessageBox.Show("Bạn có chắc là muốn xóa sản phẩm không ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {                     
                        DichVu_BLL.Instance.delP();
                        LoadData();
                    }
                }
                else if (dgvProducts.Columns[e.ColumnIndex].Name == "EditProductColumn")
                {
                    int ProductID = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductIDColumn"].Value);
                    product product = DichVu_BLL.Instance.showP(ProductID);
                    UpdateProduct update = new UpdateProduct(product);
                    update.ShowDialog();
                    LoadData();
                }
            }
        }
        public void LoadData()
        {
            dgvProducts.Rows.Clear();
            List<product> products = DichVu_BLL.Instance.getProducts();
            foreach (product product in products)
            {
                category category = DichVu_BLL.Instance.getCategoryById(Convert.ToInt32(product.id_product_category));
                dgvProducts.Rows.Add(product.id, product.product_name, product.prices, category.product_category_name, product.image_url);
            }
        }
      
    }
}
