using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login.Models
{
    public class credentials
    {
        [Key] // informing ef that this is the tables unique identifier
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // informing ef that the db will provide the value

        public int id {get; set;}
        public string userName {get; set; }
        public string password {get; set;}

        public credentials(){}
        public credentials(int id, string userName, string password)
        {
            this.id = id;
            this.userName = userName;
            this.password = password;
        }
    }
}