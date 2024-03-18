//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Brokers.Loggings;
using e_shop.Brokers.Storages;
using e_shop.Models.Auth;

namespace e_shop.Services.Storage
{
    internal class CredentialService : ICredentialService
    {
        private readonly IStorageBroker<Credential> storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public CredentialService()
        {
            this.storageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Credential AddCredential(Credential credential)
        {
            return credential is null
                 ? AddCredentialAndLogInvalidUser()
                 : ValidateAndAddCredentail(credential);
        }

        public List<Credential> GetAllCredentails()
        {
           if(this.storageBroker.GetAll().Count == 0)
            {
                return new List<Credential>();
            }
           return this.storageBroker.GetAll().ToList();
        }

        private Credential AddCredentialAndLogInvalidUser()
        {
            loggingBroker.LogError("Credential is invalid");
            return new Credential();
        }
        private Credential ValidateAndAddCredentail(Credential credential)
        {
            if (string.IsNullOrWhiteSpace(credential.UserName) || string.IsNullOrWhiteSpace(credential.Password))
            {
                loggingBroker.LogError("User details missing");
                return new Credential();
            }
            else
            {
                loggingBroker.LogSuccessUser("Signed Up Successfully");
                return storageBroker.Add(credential);
            }
        }
    }
}
