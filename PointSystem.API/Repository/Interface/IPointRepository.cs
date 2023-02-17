using PointSystem.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSystem.API.Repository.Interface
{
    public interface IPointRepository
    {
        Task Create(Point point);
    }
}
