using System.Collections.Generic;
using login.Models;

namespace login.Services
{
    public class DataService
    {
        public List<credentials> fixedData = new List<credentials>
        {
            new credentials(1, "kevincab", "Chicag0"),
        };

        public IEnumerable<credentials> GetCredentials()
        {
            return fixedData;
        }

        public List<credentials> GetListCredentials()
        {
            return fixedData;
        }

        public credentials GetFirstCredential()
        {
            return fixedData[0];
        }

        // public void AddCredential(credentials cred)
        // {
        //     //We need to add cred to our List fixed
        //     fixedData.Add(cred);
        //     var x = 1;
        // }
    }
}