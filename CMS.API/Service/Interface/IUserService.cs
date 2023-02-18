using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Service.Interface
{
    public interface IUserService
    {
        Task<User> Create(Member member);
        Task<bool> Login(User user);
    }
}
