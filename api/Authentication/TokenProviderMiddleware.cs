using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Context.Transaction;
using api.Op.Login;
using domain.Entities;
using domain.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace api.Authentication
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUnitOfWork _unitOfWork;

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options, IUnitOfWork unitOfWork)
        {
            _next = next;

            _unitOfWork = unitOfWork;

            _options = options.Value;
            ThrowIfInvalidOptions(_options);

            _serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }


            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var email = context.Request.Form["email"];
            var password = context.Request.Form["password"];

            var loginOp = new LoginOp(_unitOfWork);

            var user = new User();

            try
            {
                user = (User)loginOp.Execute(new LoginModel { Email = email, Password = password });   
                var identity = await _options.IdentityResolver(user);
            }
            catch (Exception ex) 
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var jsonException = ExceptionHandler.FormatException(ex);
                var json = JsonConvert.SerializeObject(jsonException, _serializerSettings);
                await context.Response.WriteAsync(json);
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new Claim[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("email", email)
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
        }

        private static void ThrowIfInvalidOptions(TokenProviderOptions options)
        {
            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));
            }

            if (string.IsNullOrEmpty(options.Issuer))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));
            }

            if (string.IsNullOrEmpty(options.Audience))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));
            }

            if (options.Expiration == TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));
            }

            if (options.IdentityResolver == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));
            }
        }
    }
}
