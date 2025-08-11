using CarStoreApi.Application.Interfaces;
using CarStoreApi.Domain.Entities;
using CarStoreApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.Repositorries
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<string>?> GetRolesAsync(User user)
        {
            var roles = await CustomFindAsync<UserRoles, string>(
                predicate: ur => ur.UserId == user.UserId,
                selector: r => r.Role.RoleName);

            return roles;
        }
    }
}
