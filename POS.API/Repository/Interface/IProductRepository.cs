using POS.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Repository.Interface
{
    public interface IProductRepository
    {
        Task CreateAsync(ProductModel category);
        List<ProductModel> GetAll();
        Task UpdateAsync(ProductModel category);
        Task DeleteAsync(ProductModel category);
    }
}
