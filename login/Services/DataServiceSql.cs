using System.Collections.Generic;
using login.Models;
using login.Services.Context;

namespace login.Services
{
    public class DataServiceSql
    {
        private readonly DataContext _context;
        public DataServiceSql(DataContext context)
        {
            _context = context;
        }

        //CRUD functions

        // C --> CRUD
        public int InsertCred(credentials cred)
        {
            //Adds the credentials into your DB
            var credItem = _context.Add(cred);

            //Save your changes
            _context.SaveChanges();

            //Returns the id of the newly added item back to you
            //View in postman
            return credItem.Entity.id;
        }

        //Our reading piece 
        public IEnumerable<credentials> GetCreds()
        {
            return _context.credential;
        }
    }
}