using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace Services_EF
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public List<Product> GetProductsByCategory(int cateId);
    }
}
