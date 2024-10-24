using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.AuthenticationModels;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, AuthenticationServiceOptions options)
        {
            _userRepository = userRepository;
            _options = options;
        }


        public User? ValidateUser(CredentialsRequest credentialsRequest)
        {
            if (string.IsNullOrEmpty(credentialsRequest.Username) || string.IsNullOrEmpty(credentialsRequest.Password))
            {
                return null;
            }

            var user = _userRepository.GetUserByUsername(credentialsRequest.Username);

            if (user == null || user.Password != credentialsRequest.Password)
            {
                return null;
            }

            return user;
        }


        public string Autenticar(CredentialsRequest credentialsRequest)
        {
            var user = ValidateUser(credentialsRequest);

            if (user == null)
            {
                throw new Exception("User authentication failed");
            }

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));
            claimsForToken.Add(new Claim("family_name", user.Lastname));

            if (user is Admin) claimsForToken.Add(new Claim(ClaimTypes.Role, "Admin"));
            else if (user is Owner) claimsForToken.Add(new Claim(ClaimTypes.Role, "Owner"));
            else if (user is Tenant) claimsForToken.Add(new Claim(ClaimTypes.Role, "Tenant"));

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }

        public class AuthenticationServiceOptions
        {
            public const string AuthenticationService = "AuthenticationService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}
