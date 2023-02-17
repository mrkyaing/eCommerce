using PointSystem.API.DAO;
using PointSystem.API.DomainModels;
using PointSystem.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.Repository
{
    public class PointRepository : IPointRepository
    {
        private readonly PointSystemDBContext pointSystemDBContext;

        public PointRepository(PointSystemDBContext pointSystemDBContext)
        {
            this.pointSystemDBContext = pointSystemDBContext;
        }
        public async Task Create(Point point)
        {
           await   pointSystemDBContext.Points.AddAsync(point);
           await pointSystemDBContext.SaveChangesAsync();
        }
    }
}
