using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjects;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        
        public void GenerateSampleDataset()
        {
            products.Add(new Product { Id = 1, Name = "Laptop", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 2, Name = "Smartphone", Quantity = 20, Price = 499.99 });
            products.Add(new Product { Id = 3, Name = "Tablet", Quantity = 15, Price = 299.99 });
            products.Add(new Product { Id = 4, Name = "Samsung", Quantity = 35, Price = 699.99 });
            products.Add(new Product { Id = 5, Name = "Iphonne", Quantity = 45, Price = 799.99 });
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
            {
                return false; // Product already exists, không thêm được
            }
            products.Add(product);
            return true; // Thêm thành công
        }

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            //B1: Tìm xem product muốn sửa này có tồn tại không?
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old == null)
            {
                return false; // Không tìm thấy sản phẩm để sửa
            }
            old.Name = product.Name;
            old.Quantity = product.Quantity;
            old.Price = product.Price;
            return true;
        }

        public bool DeleteProduct(int id)
        {
            Product p = GetProduct(id);
            if (p != null)
            {
                products.Remove(p);
                return true;
            }
            return false;
        }

        public bool DeleteProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }

            return DeleteProduct(product.Id);
        }
    }
}
