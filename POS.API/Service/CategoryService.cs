using POS.API.Domain;
using POS.API.Repository.Interface;
using POS.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.API.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICatetoryRepository catetoryRepository;

        public CategoryService(ICatetoryRepository catetoryRepository)
        {
            this.catetoryRepository = catetoryRepository;
        }
        public async Task CreateAsync(CategoryModel category)
        {
          await  catetoryRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(CategoryModel category)
        {
           await catetoryRepository.DeleteAsync(category);
        }

        public async Task<List<CategoryModel>> GetAllAsync()
        {
          return await catetoryRepository.GetAllAsync();
        }

        public async Task UpdateAsync(CategoryModel category)
        {
           await catetoryRepository.UpdateAsync(category);
        }
    }
}
