using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Repository.Interface
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<bool> Login(User user);
    }
}
