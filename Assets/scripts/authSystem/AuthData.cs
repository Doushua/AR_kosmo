using System;

namespace localdata
{
    [Serializable]
    public class AuthData
    {
        public string name;
        public string login;
        public string password;
        
        public AuthData(){}
        public AuthData(string name, string login, string password)
        {
            this.name = name;
            this.login = login;
            this.password = password;
        }
    }
}