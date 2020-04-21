using System.Collections.Generic;
using login.Models;

namespace login.Services
{
    public class DataService
    {
        public List<credentials> fixedData = new List<credentials>
        {
            new credentials("kevincab", "Chicag0"),
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
    }
}