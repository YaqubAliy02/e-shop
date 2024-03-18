//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------

using e_shop.Models.Auth;

namespace e_shop.Services.Auth
{
    internal interface ILogInService
    {
        bool CheckCredentialLogIn(Credential credential);
    }
}
