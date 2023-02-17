using POS.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Service.Interface
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryModel category);
        List<CategoryModel> GetAll();
        Task UpdateAsync(CategoryModel category);
        Task DeleteAsync(CategoryModel category);
    }
}
