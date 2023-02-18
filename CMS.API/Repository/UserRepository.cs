using CMS.API.DAO;
using CMS.API.DomainModels;
using CMS.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CMSDBContext _cMSDBContext;

        public UserRepository(CMSDBContext cMSDBContext) {
            this._cMSDBContext = cMSDBContext;
        }
        public async Task Create(User user)
        {
            _cMSDBContext.Users.Add(user);
            await _cMSDBContext.SaveChangesAsync();
        }

        public Task<bool> Login(User user)
        {
           bool result = false;
            var userModel = _cMSDBContext.Users.Where(x => x.Password.Equals(user.Password) && x.Email.Equals(user.Email));
            if(userModel.Any() )          
                result = true;        
            return Task.FromResult(result);
        }
    }
}
