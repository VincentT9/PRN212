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
using MyStoreWpfApp_EntityFrameWork.Models;

namespace MyStoreWpfApp_EntityFrameWork
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
            /// Tạo gốc cây
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cát Lái";
            tvCategory.Items.Add(root);
            //Truy vấn toàn bộ danh mục
            var categories = context.Categories.ToList();
            //Đưa danh mục lên TreeView: 
            foreach (var category in categories)
            {
                // Tạo node danh mục: 
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = categories;
                root.Items.Add(cate_node); // Thêm node danh mục vào gốc cây
                //Lọc sản phẩm theo danh mục:
                var products = context.Products
                    .Where(p => p.CategoryId == category.CategoryId)
                    .ToList();
                //Nạp product vào Node Danh mục tương ứng
                foreach (var product in products)
                {
                    //Tạo node cho Product:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node); // Thêm node sản phẩm vào node danh mục
                }
            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null)
            {
                return;
            }
            Category category = item.Tag as Category;
            if (category == null)
            {
                return;
            }
            LoadProductsIntoListView(category);
        }

        private void LoadProductsIntoListView(Category category)
        {
            //Lọc sản phẩm theo danh mục:
            var products = context.Products
                .Where(p => p.CategoryId == category.CategoryId)
                .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products; // Nạp sản phẩm vào ListView
        }
    }
}
