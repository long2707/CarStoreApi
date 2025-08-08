﻿using CarStoreApi.Application.DTOS.Authentication;
using CarStoreApi.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMailService _mailService;

        public AuthController(IAuthService authService, IMailService mailService)
        {
            _authService = authService;
            _mailService = mailService;
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> SignUpAsync([FromBody] RegisterRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest(new { Message = "Invalid register request" });
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _authService.Register(request);

                if (!string.IsNullOrEmpty(user.Message))
                    return BadRequest(new { Message = user.Message });

                var token = user.EmailVerificationToken;

                var confirmationLink = Url.Action("ConfirmEmail", "Auth",
                    new { email = user.Email, token = token }, Request.Scheme);

                await _mailService.SendEmailConfirmationAsync(user.Email, confirmationLink);

                return Ok(new { Message = "Registration successful. Please check your email for confirmation." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> SignAsync([FromBody] LoginRequest request)
        {
            try
            {
                if (request is null)
                {
                    return BadRequest(new { Message = "Invalid login request" });

                }
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.Login(request);

                return !string.IsNullOrEmpty(result.Message) ? BadRequest(new { Message = result.Message }) : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPost("SignWithGoogle")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> SignInWithGoogleAsync([FromBody] GoogleLoginRequest request)
        {
            if (request is null) return BadRequest(new { Message = "Invalid login request" });

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GoogleLogin(request);
            return !string.IsNullOrEmpty(result.Message) ? BadRequest(new { Message = result.Message }) : Ok(result);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> ConfirmEmailAsync(string email, string token)
        {
            try
            {
                var result = await _authService.ConfirmEmail(new ConfirmRequest { Email = email, Token = token });

                if (result)
                {
                    return Content(@"
                    <html>
                        <head>
                            <title>Email Confirmed</title>
                            <style>
                                body { font-family: Arial, sans-serif; text-align: center; padding: 50px; }
                                h1 { color: #4CAF50; }
                            </style>
                        </head>
                        <body>
                            <h1>Email Confirmed Successfully!</h1>
                            <p>Your email has been verified. You can now log in to your account.</p>
                        </body>
                    </html>", "text/html");
                }
                return BadRequest(new { Message = "Email confirmation failed" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }

        }

        [HttpPost("SignOut")]
        [Authorize]
        public async Task<ActionResult<string>> SignOutAsync(string refreshToken)
        {
            try
            {
                var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if(token is null)
                    return BadRequest(new { Message = "Token not found" });

                var result = await _authService.SignOut(token, refreshToken);

                return result.Contains("successfully") ? Ok(new { Message = result }) : BadRequest(new { Message = result });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<string>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            if (request is null)
                return BadRequest(new { Message = "Invalid request" });

            var result = await _authService.RefreshToken(request.refreshToken);

            return !result.IsAuthenticated ? StatusCode(403, new { Message = "Invalid Credentials" }) :
                Ok(new { Token = result.Token });
        }

        [HttpPost("RevokeToken")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<string>> RevokeTokenAsync(RefreshTokenRequest request)
        {
            if (request is null)
                return BadRequest(new { Message = "Invalid request" });

            var result = await _authService.RevokeToken(request.refreshToken);

            return !result ? BadRequest(new { Message = "InValid Token!" }) : Ok(new { Message = "Token Revoked Successfully!" });

        }
    }
}
