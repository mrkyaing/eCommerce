using POS.API.Domain;
using POS.API.Repository.Interface;
using POS.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.API.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task CreateAsync(ProductModel model)
        {
            model.Id = Guid.NewGuid().ToString();
          await productRepository.CreateAsync(model);
        }

        public async Task DeleteAsync(ProductModel model)
        {
           await productRepository.DeleteAsync(model);
        }

        public List<ProductModel> GetAll()
        {
          return productRepository.GetAll();
        }

        public async Task UpdateAsync(ProductModel model)
        {
           await productRepository.UpdateAsync(model);
        }
    }
}
