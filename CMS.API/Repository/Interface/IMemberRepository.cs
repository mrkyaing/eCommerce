using CMS.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Repository.Interface
{
    public interface IMemberRepository
    {
        Task Register(Member member);
        Task<List<Member>> GetList();
        Task<Member> GetById(string id);
    }
}
