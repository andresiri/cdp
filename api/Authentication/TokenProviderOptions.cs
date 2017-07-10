using System;
using System.Security.Claims;
using System.Threading.Tasks;
using domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace api.Authentication
{
    public class TokenProviderOptions
    {        
        public string Path { get; set; } = "/api/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        /// <summary>
        /// The expiration time for the generated tokens.
        /// </summary>
        /// <remarks>The default is five minutes (300 seconds).</remarks>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(120);

        public SigningCredentials SigningCredentials { get; set; }

        public Func<User, Task<ClaimsIdentity>> IdentityResolver { get; set; }
    }
}
