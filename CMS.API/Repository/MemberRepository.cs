using CMS.API.DAO;
using CMS.API.DomainModels;
using CMS.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly CMSDBContext cMSDBContext;

        public MemberRepository(CMSDBContext cMSDBContext)
        {
            this.cMSDBContext = cMSDBContext;
        }

        public async Task<Member> GetById(string id)=> cMSDBContext.Members.ToListAsync().Result.Where(x=>x.Id==id).SingleOrDefault();

        public Task<List<Member>> GetList() => cMSDBContext.Members.ToListAsync();

        public async Task Register(Member member)
        {
            member.Id = Guid.NewGuid().ToString();
            member.Code="m"+DateTime.Now.ToString("yyyyMMddHH:MM:ss").ToString();
            await cMSDBContext.Members.AddAsync(member);
            await cMSDBContext.SaveChangesAsync();
        }
    }
}
