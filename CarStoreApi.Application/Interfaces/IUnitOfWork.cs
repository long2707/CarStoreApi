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
        IUserRepository Users { get; }
        IBaseRepository<PenddingUser> PenddingUsers { get; }
        IRoleRepository Roles { get; }
        IBaseRepository<UserRoles> UserRoles { get; }
        IBaseRepository<Favorite> Favorites { get; }
        IRateRepository Rates { get; }
        IBaseRepository<CarBrand> CarBrands { get; }
        IBaseRepository<CarFeatures> CarFeatures { get; }
        IBaseRepository<CarModel> CarModels { get; }
        IFeatureRepository Features { get; }
        IBaseRepository<ModelGallery> ModelGalleries { get; }
        IBaseRepository<RefreshToken> RefreshTokens { get; }
        IBaseRepository<BlacklistedToken> blacklistedTokens { get; }
        Task SaveChangesAsync();
    }
}
