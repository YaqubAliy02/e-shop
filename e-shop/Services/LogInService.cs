using e_shop.Brokers.Loggings;
using e_shop.Brokers.Storages;
using e_shop.Models;

namespace e_shop.Services
{
    internal class LogInService : ILogInService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public LogInService()
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
        private Credential AddCredentialAndLogInvalidUser()
        {
            this.loggingBroker.LogError("Credential is invalid");
            return new Credential();
        }
        private Credential ValidateAndAddCredentail(Credential credential)
        {
            if(String.IsNullOrWhiteSpace(credential.UserName) || String.IsNullOrWhiteSpace(credential.Password))
            {
                this.loggingBroker.LogError("User details missing");
                return new Credential();
            }
            else
            {
                this.loggingBroker.LogSuccessUser("Signed Up Successfully");
                return this.storageBroker.AddCredential(credential);
            }
        }

        public bool CheckCredentialLogIn(Credential credential)
        {
            Credential[] credentials = this.storageBroker.GetAllCredentials();
            foreach(var cred in credentials)
            {
                if(cred.UserName == credential.UserName && cred.Password == credential.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
