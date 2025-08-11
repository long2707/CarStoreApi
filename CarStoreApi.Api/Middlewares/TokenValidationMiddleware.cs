﻿using CarStoreApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApi.Api.Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if ((!string.IsNullOrEmpty(token)))
            {
                var isBlacklisted = await dbContext.blacklistedTokens.AnyAsync(t => t.Token == token);

                if (isBlacklisted)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token is blacklisted");
                    return;
                }
            }
            await _next(context);
        }
    }
}
