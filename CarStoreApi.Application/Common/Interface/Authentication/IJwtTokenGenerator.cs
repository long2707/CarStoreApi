using CarStoreApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Common.Interface.Authentication
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateJwtToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}
