using CarStoreApi.Application.DTOS.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResult> Register(RegisterRequest request);
        Task<AuthResult> Login(LoginRequest request);
        Task<AuthResult> GoogleLogin(GoogleLoginRequest request);
        Task<bool> ConfirmEmail(ConfirmRequest request);
        string GenerateEmailConfirmationToken(string email);
        Task<string> SignOut(string token, string refreshToken);
        Task<AuthResult> RefreshToken(string refreshToken);
        Task<bool> RevokeToken(string token);
    }
}
