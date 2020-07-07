using System;
using System.Collections.Generic;
using System.Linq;
using login.Models;
using login.Services.Context;

namespace login.Services {
    public class DataServiceSql {
        private readonly DataContext _context;
        public DataServiceSql (DataContext context) {
            _context = context;
        }

        //CRUD functions

        // C --> CRUD

        public int InsertCred (credentials cred) {
            //Adds the credentials into your DB
            var credItem = _context.Add (cred);

            //Save your changes
            _context.SaveChanges ();

            //Returns the id of the newly added item back to you
            //View in postman
            return credItem.Entity.id;
        }

        //Our reading piece 
        // R --> CRUD
        public IEnumerable<credentials> GetCreds () {
            return _context.credential;
        }

        public credentials GetAccountById (int id) {
            //be sure to add using System.Linq
            return _context.credential.SingleOrDefault (x => x.id == id);
        }

        public int getId(string cred){
             var exist = _context.credential.First (x => x.userName == cred);
             return exist.id;
        }

        //Our update piece
        // U --> CRUD
        public bool UpdateAccountUsername (credentials cred) {

            try {
                var entry = _context.credential.First (e => e.id == cred.id);
                entry.userName = cred.userName;
                _context.Update<credentials>(entry);
                // _context.Entry (entry).CurrentValues.SetValues (cred);
               _context.SaveChanges ();
               return true;
            } catch (Exception e) {
                // handle correct exception
                // log error
                return false;
            }
            // var credId = GetAccountById(cred.id);
            // _context.Update<credentials>(cred);
            // if you don't do a check for it being 0, then it would update all the fields
            // return _context.SaveChanges() !=0;
        }
        
        public bool UpdateAccountPassword (credentials cred) {

            try {
                var entry = _context.credential.First (e => e.id == cred.id);
                entry.password = cred.password;
                _context.Update<credentials>(entry);
                // _context.Entry (entry).CurrentValues.SetValues (cred);
               _context.SaveChanges ();
               return true;
            } catch (Exception e) {
                // handle correct exception
                // log error
                return false;
            }
            // var credId = GetAccountById(cred.id);
            // _context.Update<credentials>(cred);
            // if you don't do a check for it being 0, then it would update all the fields
            // return _context.SaveChanges() !=0;
        }

        //D is for Delete
        public bool DeleteTrackById (int id) {
            var cred = GetAccountById (id);
            _context.Remove (cred);
            return _context.SaveChanges () != 0;
        }
    }
}