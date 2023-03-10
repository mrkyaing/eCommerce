using POS.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Service.Interface
{
    public interface IProductService
    {
        Task CreateAsync(ProductModel model);
        Task<List<ProductModel>> GetAllAsync();
        Task UpdateAsync(ProductModel model);
        Task DeleteAsync(ProductModel model);
    }
}
