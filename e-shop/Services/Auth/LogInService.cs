//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Brokers.Storages;
using e_shop.Models.Auth;

namespace e_shop.Services.Auth
{
    internal class LogInService : ILogInService
    {
        private readonly IStorageBroker<Credential> storageBroker;
        public LogInService()
        {
            this.storageBroker = new FileStorageBroker();
        }
        public bool CheckCredentialLogIn(Credential credential)
        {
            foreach (Credential credentialItem in storageBroker.GetAll())
            {
                if (credential.UserName == credentialItem.UserName && credentialItem.Password == credential.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
