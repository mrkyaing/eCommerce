using AutoMapper;
using CMS.API.DomainModels;
using CMS.API.Repository;
using CMS.API.Repository.Interface;
using CMS.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            this._memberRepository = memberRepository;
            this._mapper = mapper;
        }
        public  async Task<MemberModel> GetById(string id)
        {
            var member=await _memberRepository.GetById(id);
            var memberModel = _mapper.Map<MemberModel>(member);
            return memberModel;
        }

        public async Task<List<MemberModel>> GetList()
        {
            var members= await _memberRepository.GetList();
            var memberModels = _mapper.Map<List<MemberModel>>(members);
            return memberModels;
        }
        public async Task Register(Member member)
        {
            member.Id=Guid.NewGuid().ToString();
            await  _memberRepository.Register(member);
        }
    }
}
