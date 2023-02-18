using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Service.Interface
{
    public interface IMemberService
    {
        Task Register(Member member);
        Task<List<MemberModel>> GetList();
        Task<MemberModel> GetById(string id);
    }
}
