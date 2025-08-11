using CarStoreApi.Application.Interfaces;
using CarStoreApi.Domain.Entities;
using CarStoreApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.Repositorries
{
    public class RateRepository : BaseRepository<Rate>, IRateRepository
    {
        private readonly AppDbContext _context;

        public RateRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<double> GetAverageRate(Guid carId)
        {
            var average = await _context.Rates
            .Where(r => r.CarModelId == carId)
            .AverageAsync(r => (double?)r.RateValue) ?? 0;

            return Math.Round(average, 2);
        }
    }
}
