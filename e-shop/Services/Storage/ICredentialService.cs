//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Auth;

namespace e_shop.Services.Storage
{
    internal interface ICredentialService
    {
        List<Credential> GetAllCredentails();
        Credential AddCredential(Credential credential);
    }
}
