using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Interfaces
{
    public interface IRateRepository : IBaseRepository<Rate>
    {
        Task<double> GetAverageRate(Guid carId);
    }
}
