using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string email);
        Task<User?> FindByNameAsync(string userName);
        Task<User?> FindByPhoneAsync(string phone);
        Task<string?> AddToRoleAsync(Guid userId, string role);
    }
}
