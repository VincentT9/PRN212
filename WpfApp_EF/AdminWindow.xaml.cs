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
using BusinessObjects_EF;
using DataAccessLayer_EF;
using Services_EF;

namespace WpfApp_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService();

        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesAndProductsIntoTreeView();
        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            tvCategory.Items.Clear();
            //Tạo nút gốc:
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cát Lái";
            tvCategory.Items.Add(root);
            //Nạp toàn bộ Danh mục lên cây: 
            List<Category> categories = categoryService
                                        .GetCategories();
            foreach (Category category in categories)
            {
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                //Nạp sản phẩm theo danh mục
                List<Product> products = productService
                                        .GetProductsByCategory(category.CategoryId);
                category.Products = products;
                foreach (Product product in category.Products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null) return;
            object data = item.Tag;
            List<Product> products = null;
            if (data == null)
            {// Người dùng nhấn vào nút gốc
                products = productService.GetProducts();
            }
            else if (data is Category)
            {// Người dùng nhấn vào nút Category
                Category cate = (Category)data;
                products = productService.GetProductsByCategory(cate.CategoryId);
            }
            else if (data is Product)
            {// Người dùng nhấn vào Product
                products = new List<Product>();
                products.Add((Product)data);
            }
            //nạp lên list View
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
    }
}
