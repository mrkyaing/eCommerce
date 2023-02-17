using POS.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Repository.Interface
{
    public interface ICatetoryRepository
    {
        Task CreateAsync(CategoryModel category);
        List<CategoryModel> GetAllAsync();
        Task UpdateAsync(CategoryModel category);
        Task DeleteAsync(CategoryModel category);
    }
}
