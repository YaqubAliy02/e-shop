using e_shop.Models;

namespace e_shop.Services
{
    internal interface ILogInService
    {
        bool CheckCredentialLogIn(Credential credential);
        Credential AddCredential(Credential credential);
    }
}
