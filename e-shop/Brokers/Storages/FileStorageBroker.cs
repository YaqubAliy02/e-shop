using e_shop.Models;
namespace e_shop.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FILEPATH = "../../../Assets/User.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public Credential AddCredential(Credential credential)
        {
            string userLine = $"{credential.UserName}-{credential.Password}\n";
            File.AppendAllText(FILEPATH, userLine);
            return credential;
        }
        public Credential[] GetAllCredentials()
        {
            string[] credentialLines = File.ReadAllLines(FILEPATH);
            int credentialLength = credentialLines.Length;
            Credential[] credentials = new Credential[credentialLength];

            for(int iteration = 0; iteration < credentialLength; iteration++)
            {
                string credentialLine = credentialLines[iteration];
                string[] credentialProperties = credentialLine.Split("-");
                Credential credential = new Credential
                {
                    UserName = credentialProperties[0],
                    Password = credentialProperties[1],
                };
                credentials[iteration] = credential;
            }
            return credentials;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FILEPATH);
            if (fileExists is false) 
            {
                   File.Create(FILEPATH).Close();
            }
        }
    }
}