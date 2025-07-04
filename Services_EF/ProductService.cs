using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using Repositories_EF;

namespace Services_EF
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<Product> GetProductsByCategory(int cateId)
        {
            return _productRepository.GetProductsByCategory(cateId);
        }
    }
}
