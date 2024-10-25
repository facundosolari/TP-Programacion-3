using Application.Models.AuthenticationModels;

namespace Application.Interfaces;
public interface IAuthenticationService
{
    string Authenticate(CredentialsRequest credentialRequest);
}
