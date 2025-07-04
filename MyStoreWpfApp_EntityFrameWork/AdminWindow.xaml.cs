using MyStoreWpfApp_EntityFramework.Models;
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

namespace MyStoreWpfApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesIntoTreeView();
        }

        private void LoadCategoriesIntoTreeView()
        {
            //Tạo Gốc cây:
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cát Lát";
            tvCategory.Items.Add(root);
            //Truy vấn toàn bộ danh mục:
            var categories = context.Categories.ToList();
            //dưa danh mục lên Treeview:
            foreach (var category in categories)
            {
                //Tạo node danh mục:
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);
                //lọc Sản phẩm theo danh mục:
                var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
                //nạp product vào Node Danh mục tương ứng:
                foreach(var product in products)
                {
                    //Tạo node cho Product:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag =product;
                    cate_node.Items.Add(product_node);
                }    
            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) 
                return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null) 
                return;
            Category category = item.Tag as Category;
            if (category == null) 
                return;
            LoadProductsIntoListView(category);
        }

        private void LoadProductsIntoListView(Category category)
        {
            //lọc Sản phẩm theo danh mục:
            var products = context.Products
                .Where(x => x.CategoryId == category.CategoryId)
                .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource=products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count == 0) 
                return;
            Product product = e.AddedItems[0] as Product;
            DisplayProductDetail(product);
        }
        void DisplayProductDetail(Product product)
        {
            if(product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            else
            {
                txtId.Text = product.ProductId + "";
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock + "";
                txtPrice.Text = product.UnitPrice + "";
            }   
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bước 1: Tìm Danh mục mà ta muốn lưu Product vào
                //Bước 2: Tạo đối tượng Product muốn lưu
                //Bước 3: Gán giá trị cho các thuộc tính của Product và lưu
                //Bước 4: Thực hiện cập nhật lại giao diện TreeView, ListView

                //--- CHI TIẾT ----:
                //Bước 1: Tìm Danh mục mà ta muốn lưu Product vào
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node == null)
                {
                    MessageBox.Show(
                        "Bạn cần chọn Danh mục trước",
                        "Lỗi lưu Sản phẩm",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                Category category = cate_node.Tag as Category;
                if (category == null)
                {
                    MessageBox.Show(
                       "Bạn cần chọn Danh mục trước",
                       "Lỗi lưu Sản phẩm",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                }
                //Bước 2: Tạo đối tượng Product muốn lưu
                Product product = new Product();
                //Bước 3: Gán giá trị cho các thuộc tính của Product và lưu
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.CategoryId = category.CategoryId;
                context.Products.Add(product);
                context.SaveChanges();
                //Bước 4: Thực hiện cập nhật lại giao diện TreeView, ListView
                //Bước 4.1 Nạp lại TreeView - Tạo Product node cho Cate node:
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;
                cate_node.Items.Add(product_node);
                //Bước 4.2 Nạp lại Listview:
                LoadProductsIntoListView(category);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi tè lè : "+ex.Message,"Lỗi",
                    MessageBoxButton.OK,MessageBoxImage.Error);
            }            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Bước 1: Tìm sản phẩm muốn sửa trước
            //Bước 2: Tiến hành thay đổi giá trị các thuộc tính
            //Bước 3: Thực hiện lưu thay đổi
            //Bước 4: Cập nhật lại giao diện TreeView và ListView
            //---CHI TIẾT----:
            //Bước 1: Tìm sản phẩm muốn sửa trước:
            int id = int.Parse(txtId.Text);
            Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) 
            {
                MessageBox.Show(
                    "Không tìm thấy sản phẩm để sửa, check lại ID",
                    "Lỗi sửa",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            //Bước 2: Tiến hành thay đổi giá trị các thuộc tính
            product.ProductName = txtName.Text;
            product.UnitsInStock = short.Parse(txtQuantity.Text);
            product.UnitPrice= decimal.Parse(txtPrice.Text);
            //Bước 3: Thực hiện lưu thay đổi
            context.SaveChanges();
            //Bước 4: Cập nhật lại giao diện TreeView và ListView
            //(Tự làm trong 15 phút)
            //Bước 4.1 Nạp lại các Product node cho Cate node:
            TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
            if (cate_node != null)
            {
                Category category = cate_node.Tag as Category;
                if (category != null)
                {
                    //Xóa toàn bộ node CON cũ của cate_node:
                    cate_node.Items.Clear();
                    //nạp lại Product:
                    //lọc Sản phẩm theo danh mục:
                    var products = context.Products
                        .Where(x => x.CategoryId == category.CategoryId)
                        .ToList();
                    //nạp product vào Node Danh mục tương ứng:
                    foreach (var product_update in products)
                    {
                        //Tạo node cho Product:
                        TreeViewItem product_node = new TreeViewItem();
                        product_node.Header = product_update.ProductName;
                        product_node.Tag = product_update;
                        cate_node.Items.Add(product_node);
                    }
                    //Bước 4.2 Nạp lại ListView:
                    LoadProductsIntoListView(category);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bước 1: Tìm sản phẩm để xóa
                //Bước 2: Hỏi xác thực có muốn xóa hay không
                //Bước 3: Tiến hành xóa nếu đồng ý
                //Bước 4: Cập nhật lại giao diện TreeView và ListView
                //------CHI TIẾT----------:
                //Bước 1: Tìm sản phẩm để xóa:
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show(
                        $"Không tìm thấy sản phẩm nào có mã ={id} để xóa",
                        "Xóa lỗi",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult result = MessageBox.Show(
                    $"Thím có chắc chắn muốn xóa sản phẩm [{product.ProductName}] không?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                //Bước 3: Tiến hành xóa nếu đồng ý
                context.Products.Remove(product);
                context.SaveChanges();
                //Bước 4: Cập nhật lại giao diện TreeView và ListView
                //(bắt chước chức năng cập nhật-->15p thực hiện)
                //Bước 4.1 Nạp lại các Product node cho Cate node:
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node != null)
                {
                    Category category = cate_node.Tag as Category;
                    if (category != null)
                    {
                        //Xóa toàn bộ node CON cũ của cate_node:
                        cate_node.Items.Clear();
                        //nạp lại Product:
                        //lọc Sản phẩm theo danh mục:
                        var products = context.Products
                            .Where(x => x.CategoryId == category.CategoryId)
                            .ToList();
                        //nạp product vào Node Danh mục tương ứng:
                        foreach (var product_update in products)
                        {
                            //Tạo node cho Product:
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_node.Items.Add(product_node);
                        }
                        //Bước 4.2 Nạp lại ListView:
                        LoadProductsIntoListView(category);
                        //xóa chi tiết:
                        DisplayProductDetail(null);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi tè lè : " + ex.Message, "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }
    }
}
