using PointSystem.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.Service.Interface
{
    public interface IPointService
    {
        Task<int> CalculatePoint(MemberPointModel memberPointModel);
        Task CreatePoint(Point point);
        Task AddPointToMember(Point point, MemberPointModel memberPointModel);
    }
}
