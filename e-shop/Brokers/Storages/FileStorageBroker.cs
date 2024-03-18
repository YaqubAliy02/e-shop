//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Auth;
namespace e_shop.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker<Credential>
    {
        private const string FILEPATH = "../../../Assets/User.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public Credential Add(Credential credential)
        {
            string userLine = $"{credential.UserName}-{credential.Password}\n";
            File.AppendAllText(FILEPATH, userLine);
            return credential;
        }
        public List<Credential> GetAll()
        {
            List<Credential> credentials = new List<Credential>();
            string[] credentialLines = File.ReadAllLines(FILEPATH);
           
            foreach(string credentialLine in credentialLines)
            {
                string[] credentialProperties = credentialLine.Split("-");
                credentials.Add(new Credential()
                {
                    UserName = credentialProperties[0],
                    Password = credentialProperties[1],
                });
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