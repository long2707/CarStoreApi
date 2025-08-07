using CarStoreApi.Application.DTOS.Favorite;
using CarStoreApi.Application.DTOS.Feature;
using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Interfaces
{
    public interface IFeatureRepository:IBaseRepository<Feature>
    {
        Task<string> AddFeatureToCar(ToggleFeatureFromCarDto request);
        Task<string> RemoveFeatureFromCar(ToggleFeatureFromCarDto request);


    }
}
