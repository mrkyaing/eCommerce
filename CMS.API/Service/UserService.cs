using CMS.API.DomainModels;
using CMS.API.Repository.Interface;
using CMS.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<bool> Login(User user)=>await _userRepository.Login(user);
        public Task<User> Create(Member member)
        {
            User user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.Email = member.Name + "@gmail.com";
            user.Password = "cms101";
            user.MemberId= member.Id;
            _userRepository.Create(user);
            return Task.FromResult(user);
        }   
    }
}
