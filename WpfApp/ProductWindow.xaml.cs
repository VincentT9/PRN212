using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BussinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();
        bool isCompleted = false;
        public ProductWindow()
        {
            InitializeComponent();

            isCompleted = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isCompleted = true;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
            {
                return; //vì chưa thực hiện thao tác dữ liệu xong
            }
            if (e.AddedItems.Count < 0)
            {
                return; //vì người dùng chưa chọn dòng nào
            }
            //lấy Product đang chọn ra: 
            Product p = e.AddedItems[0] as Product;
            if (p == null) return;
            txtId.Text = p.Id.ToString();
            txtName.Text = p.Name;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString(); 
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Product product = new Product
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Price = double.Parse(txtPrice.Text)
                };

                bool kq = productService.SaveProduct(product);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();

                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lung tung rồi, chi tiết: " + ex.Message);
            }

            
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;

                int id = int.Parse(txtId.Text);
                Product p = productService.GetProduct(id);
                if (p == null)
                {
                    return; // không tìm thấy để sửa
                }
                // nếu tìm thấy thì thay đổi dữ liệu: 
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = double.Parse(txtPrice.Text);

                bool kq = productService.UpdateProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }

                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật, chi tiết: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // luôn luôn phải xác thực có muốn xóa hay không
                MessageBoxResult ret = MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này không?", "Xác nhận xóa",
                     MessageBoxButton.YesNo, MessageBoxImage.Question
                );
                if (ret == MessageBoxResult.No)
                {
                    return; //không xóa khi chọn NO
                }
                isCompleted = false;

                int id =int.Parse(txtId.Text);
                bool kq = productService.DeleteProduct(id);
                if (kq == false) return;

                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = productService.GetProducts();
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";

                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác xóa lỗi, chi tiết: " + ex.Message);
            }
        }
    }
}
