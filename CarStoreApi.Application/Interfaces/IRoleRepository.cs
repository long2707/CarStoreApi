using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Interfaces
{
    public interface IRoleRepository :IBaseRepository<Role>
    {
        Task<List<string>?> GetRolesAsync(User user);
    }
}
