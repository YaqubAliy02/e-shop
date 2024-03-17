using e_shop.Models;

namespace e_shop.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Credential AddCredential(Credential credential);
        Credential[] GetAllCredentials();

    }
}
