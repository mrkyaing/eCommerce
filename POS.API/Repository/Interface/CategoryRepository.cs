using Microsoft.EntityFrameworkCore;
using POS.API.DAO;
using POS.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Repository.Interface
{
    public class CategoryRepository : ICatetoryRepository
    {
        private readonly POSDBContext _pOSDBContext;

        public CategoryRepository(POSDBContext pOSDBContext)
        {
            _pOSDBContext = pOSDBContext;
        }

        public async Task CreateAsync(CategoryModel category)
        {
          await _pOSDBContext.Categories.AddAsync(category);
          await _pOSDBContext.SaveChangesAsync();
        }

        public  async Task DeleteAsync(CategoryModel category)
        {
            _pOSDBContext.Categories.Remove(category);
        }

        public List<CategoryModel> GetAllAsync()
        {
            var categories= _pOSDBContext.Categories.ToList();
            return categories;
        }

        public async Task UpdateAsync(CategoryModel category)
        {
            _pOSDBContext.Categories.Update(category);
        }
    }
}
