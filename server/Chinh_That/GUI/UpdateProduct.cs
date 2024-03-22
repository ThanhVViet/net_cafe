using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Chinh_That.DTO;
using Chinh_That.BLL;

namespace Chinh_That
{
    public partial class UpdateProduct : Form
    {
        product product;
        public UpdateProduct(product product)
        {
            InitializeComponent();
            this.product = product;
            SetCBB();
        }

        private void Update_Products_Load(object sender, EventArgs e)
        {
            txtProductID.Text = product.id.ToString();
            txtProductName.Text = product.product_name;
            txtProductPrice.Text = product.prices.ToString();
            cbbProductCategory.Text = product.category.product_category_name;
            MemoryStream ms = new MemoryStream(product.image_url);
            picP.Image = Image.FromStream(ms);
        }
        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thay đổi thông tin không ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MemoryStream ms = new MemoryStream();
                picP.Image.Save(ms, picP.Image.RawFormat);
                byte[] PP = ms.GetBuffer();
                ms.Close();        
                int ProductID = Convert.ToInt32(txtProductID.Text);
                product pd = DichVu_BLL.Instance.showP(ProductID);
                pd.product_name = txtProductName.Text;
                pd.prices = Convert.ToInt32(txtProductPrice.Text);
                pd.id_product_category = ((CBBItem)cbbProductCategory.SelectedItem).Value;
                pd.image_url = PP;
                DichVu_BLL.Instance.editP(pd);
            }
        }
        public void SetCBB()
        {
            //QuanLiQuanNetEntities db = new QuanLiQuanNetEntities();
            //foreach (category i in db.categories)
            //{
            //    cbbProductCategory.Items.Add(new CBBItem
            //    {
            //        Value = i.id,
            //        Text = i.product_category_name
            //    });
            //}
            cbbProductCategory.Items.AddRange(DichVu_BLL.Instance.getCBB().ToArray()); 
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ProductPictureBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picP.ImageLocation = open.FileName;
            }
        }
    } 
}
