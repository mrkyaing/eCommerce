using Microsoft.EntityFrameworkCore;
using POS.API.DAO;
using POS.API.Domain;
using POS.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly POSDBContext _pOSDBContext;

        public ProductRepository(POSDBContext pOSDBContext)
        {
            _pOSDBContext = pOSDBContext;
        }

        public async Task CreateAsync(ProductModel model)
        {
            await _pOSDBContext.Products.AddAsync(model);
            await _pOSDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductModel model)
        {
            _pOSDBContext.Products.Remove(model);
            await _pOSDBContext.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
          return await _pOSDBContext.Products.ToListAsync(); 
        }


        public async Task UpdateAsync(ProductModel model)
        {
            _pOSDBContext.Products.Update(model);
            await _pOSDBContext.SaveChangesAsync();
        }
    }
}
