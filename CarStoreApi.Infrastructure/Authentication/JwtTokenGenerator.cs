using CarStoreApi.Application.Common.Interface.Authentication;
using CarStoreApi.Domain.Entities;
using CarStoreApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly AppDbContext _context;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, AppDbContext context)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var roles = await _context.UserRoles.Where(ur => ur.UserId == user.UserId).Select(ur => ur.Role.RoleName)
                .ToListAsync();
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,
            new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(),
            ClaimValueTypes.Integer64),
        }.Union(roleClaims);

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims = claims,
                signingCredentials: signingCredentials,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes)
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            return new RefreshToken { Token = Convert.ToBase64String(randomNumber) };
        }
    }
}
