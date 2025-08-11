using CarStoreApi.Application.DTOS.Feature;
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
    public class FeatureRepository : BaseRepository<Feature>, IFeatureRepository
    {
        private readonly AppDbContext _context;

        public FeatureRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<string> AddFeatureToCar(ToggleFeatureFromCarDto request)
        {
            try
            {

                var car = await _context.CarModels.FindAsync(request.CarId);
                var feature = await GetByIdAsync(request.FeatureId);
                if (car == null || car.IsDeleted || feature == null || feature.IsDeleted)
                    return "Car not found.";

                var carFeature = await _context.CarFeatures.FirstOrDefaultAsync(cf => cf.CarModelId == request.CarId);
                
                if(carFeature != null)
                {
                    if (!carFeature.IsDeleted)
                    {
                        return "Feature already added to this car.";
                    }
                    carFeature.IsDeleted = false;
                    return "Feature re-added to the car successfully.";
                }

                var newCarFeature = new CarFeatures
                {
                    CarModelId = request.CarId,
                    FeatureId = request.FeatureId,
                   
                };

                await _context.CarFeatures.AddAsync(newCarFeature);
                await _context.SaveChangesAsync();
                return "Feature added to the car successfully.";

            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding feature to car: {ex.Message}");
            }
        }
        public async Task<string> RemoveFeatureFromCar(ToggleFeatureFromCarDto request)
        {
            try
            {
                if (request.CarId == Guid.Empty || request.FeatureId == Guid.Empty)
                {
                    return "Invaild request";
                }

                var car = await _context.CarModels.FindAsync(request.CarId);
                var feature = await GetByIdAsync(request.FeatureId);

                if (car == null || car.IsDeleted|| feature == null || feature.IsDeleted)
                    return "Car not found.";

                var carFeature = await _context.CarFeatures.FirstOrDefaultAsync(cf => cf.CarModelId == request.CarId && cf.FeatureId == request.FeatureId);
                
                if(carFeature == null || carFeature.IsDeleted)
                {
                    return "Feature not found for this car.";
                }
                carFeature.IsDeleted = true;
                _context.CarFeatures.Update(carFeature);
                await _context.SaveChangesAsync();
                return "Feature removed from car successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing feature from car: {ex.Message}");
            }   
        }
    }

}
