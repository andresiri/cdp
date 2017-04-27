﻿using System;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using api.Authentication;
using domain.Entities;

namespace api
{
    public partial class Startup
    {
        public SymmetricSecurityKey signingKey;

        private void ConfigureAuth(IApplicationBuilder app)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            var tokenProviderOptions = new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = GetIdentity
            };

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                // Validate the token expiry
                ValidateLifetime = true,
                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    AuthenticationScheme = "Cookie",
            //    CookieName = Configuration.GetSection("TokenAuthentication:CookieName").Value,
            //    TicketDataFormat = new CustomJwtDataFormat(
            //        SecurityAlgorithms.HmacSha256,
            //        tokenValidationParameters)
            //});

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderOptions));
        }

        private Task<ClaimsIdentity> GetIdentity(User user)
        {
            try
            {
                if (user != null)
                {
                    return Task.FromResult(new ClaimsIdentity(new System.Security.Principal.GenericIdentity(user.Email, "Token"), new Claim[] { }));
                }

                // Credentials are invalid, or account doesn't exist
                return Task.FromResult<ClaimsIdentity>(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
