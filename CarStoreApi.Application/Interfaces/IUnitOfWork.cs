using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository User { get; }
        IBaseRepository<PenddingUser> PenddingUser { get; }
        IRoleRepository Role { get; }
        IBaseRepository<UserRoles> UserRoles { get; }
        IRateRepository Rate { get; }
        IBaseRepository<CarBrand> CarBrand { get; }
        IBaseRepository<CarFeatures> CarFeatures { get; }
        IBaseRepository<CarModel> CarModel { get; }
        IFeatureRepository Feature { get; }
        IBaseRepository<ModelGallery> ModelGalleries { get; }
        IBaseRepository<RefreshToken> RefreshToken { get; }
        IBaseRepository<BlacklistedToken> blacklistedTokens { get; }
        Task SaveChangesAsync();
    }
}
