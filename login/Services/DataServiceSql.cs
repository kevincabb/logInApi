using System.Collections.Generic;
using System.Linq;
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
        
        // public bool InsertCred(credentials cred)
        // {
        //     //Adds the credentials into your DB
        //     var credItem = _context.Add(cred);

        //     //Save your changes
        //     _context.SaveChanges();

        //     //Returns bool of the newly added item back to you
        //     //View in postman
        //     return true;
        // }
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
        // R --> CRUD
        public IEnumerable<credentials> GetCreds()
        {
            return _context.credential;
        }

        public credentials GetAccountById(int id)
        {
            //be sure to add using System.Linq
            return _context.credential.SingleOrDefault(x => x.id == id);
        }

        //Our update piece
        // U --> CRUD
        public bool UpdateAccount(credentials cred)
        {
            _context.Update<credentials>(cred);
            //if you don't do a check for it being 0, then it would update all the fields
            return _context.SaveChanges() !=0;
        }

        //D is for Delete
        public bool DeleteTrackById(int id)
        {
            var cred = GetAccountById(id);
            _context.Remove(cred);
            return _context.SaveChanges() != 0;
        }
    }
}