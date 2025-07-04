using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects_EF;

namespace DataAccessLayer_EF
{
    public class CategoryDAO
    {
        MyStoreContext context = new MyStoreContext();

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }  
    }
}
