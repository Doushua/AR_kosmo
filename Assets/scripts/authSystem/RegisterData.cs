using System;

namespace localdata
{
    [Serializable]
    public class RegisterData
    {
        public string name;
        public string login;
        public string password;
        public string confirmPassword;
        
        public RegisterData(string name, string login, string password, string confirmPassword)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.confirmPassword = confirmPassword;   
        }
    }
}