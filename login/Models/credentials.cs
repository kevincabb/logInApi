using System;

namespace login.Models
{
    public class credentials
    {
        public string userName {get; set; }
        public string password {get; set;}

        public credentials(){}
        public credentials(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}