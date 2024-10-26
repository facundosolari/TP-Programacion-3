using Application.Interfaces;
using Application.Models.AuthenticationModels;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationServiceOptions _options;

        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticationServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        private User? ValidateUser(CredentialsRequest credentialsRequest) // Cambiado a CredentialsRequest
        {
            if (string.IsNullOrEmpty(credentialsRequest.Username) || string.IsNullOrEmpty(credentialsRequest.Password))
                return null;

            var user = _userRepository.GetUserByUsername(credentialsRequest.Username); // Asumiendo que tienes este método

            if (user == null) return null;

            // Aquí puedes incluir lógica de validación del tipo de usuario si es necesario
            if (user.Password == credentialsRequest.Password) // Esto debería ser un método de comparación más seguro
            {
                return user;
            }

            return null;
        }

        public string Authenticate(CredentialsRequest credentialsRequest) // Cambiado a CredentialsRequest
        {
            var user = ValidateUser(credentialsRequest);

            if (user == null)
            {
                throw new Exception("Usuario incorrecto");
            }

            // Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("given_name", user.Name),
                new Claim("family_name", user.Lastname)
            };

            // Asigna el rol basado en el tipo de usuario
            if (user is Admin) claimsForToken.Add(new Claim(ClaimTypes.Role, "Admin"));
            else if (user is Owner) claimsForToken.Add(new Claim(ClaimTypes.Role, "Owner"));
            else if (user is Tenant) claimsForToken.Add(new Claim(ClaimTypes.Role, "Tenant"));

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }
    }
}

