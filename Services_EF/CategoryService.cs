using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;
using Repositories_EF;

namespace Services_EF
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }
        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
