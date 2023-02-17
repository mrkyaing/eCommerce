using PointSystem.API.DomainModels;
using PointSystem.API.Repository.Interface;
using PointSystem.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.Service
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;

        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }
        public Task AddPointToMember(int point, string member)
        {
            throw new NotImplementedException();
        }

        public Task<int> CalculatePoint(MemberPointModel memberPointModel)
        {
            int point = 0;
            foreach(var item in memberPointModel?.OrderItems)
            {
                var isNonAlcohol = item?.Order?.Product?.Category?.Name;
                double priceOfNonAlcohol = (double)(item?.Order?.Product?.Price);
                if (isNonAlcohol.Equals("NonAlcohol") && priceOfNonAlcohol==100)
                {
                    point += 10;
                }
            }
            return Task.FromResult(point);
        }

        public async Task CreatePoint(Point p)
        {
           await _pointRepository.Create(p);
        }
    }
}
