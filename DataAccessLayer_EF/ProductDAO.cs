using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace DataAccessLayer_EF
{
    public class ProductDAO
    {
        MyStoreContext context = new MyStoreContext();
        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return context.Products
                .Where(p => p.CategoryId == cateId)
                .ToList();
        }
        
    }
}
