using System.Collections.Generic;
using login.Models;
using login.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CredController
    {
        readonly DataServiceSql _dataFromSql;
        public CredController(DataServiceSql data)
        {
            _dataFromSql = data;
        }

        [HttpGet]
        public IEnumerable<credentials> GetCreds()
        {
            return _dataFromSql.GetCreds();
        }

        [HttpGet("{cred}")]
        public int getId(string cred){
            return _dataFromSql.getId(cred);
        }

        [HttpGet("account/{id}")]
        public credentials getAccount(int id){
            return _dataFromSql.GetAccountById(id);
        }

        [HttpPost("check")]
        public bool CheckSCred(credentials credToAdd)
        {
            List<credentials> creds =new List<credentials>(_dataFromSql.GetCreds());
            foreach(var item in creds)
            {
                if(credToAdd.userName == item.userName){
                    return true;
                }
            }
            //Check if username in DB already(duplicate)
            return false;
        }
        [HttpPost("logincheck")]
        public bool CheckLogin(credentials credToAdd)
        {
            List<credentials> creds =new List<credentials>(_dataFromSql.GetCreds());
            foreach(var item in creds)
            {
                if(credToAdd.userName == item.userName && credToAdd.password == item.password){
                    return true;
                }
            }
            //Check if username in DB already(duplicate)
            return false;
        }

        [HttpPost("add")]
        public int AddCred(credentials credToAdd){
            return _dataFromSql.InsertCred(credToAdd);
        }

        [HttpPost("updateusername")]
        public bool UpdateCredUserName(credentials credToUpdate)
        {
            return _dataFromSql.UpdateAccountUsername(credToUpdate);
            // List<credentials> creds =new List<credentials>(_dataFromSql.GetCreds());
            // foreach(var item in creds){
            //     if(credToUpdate.id == item.id){
                   
            //          ;
            //     }
            // }
            // return false;
        }

        [HttpPost("updatepassword")]
        public bool UpdateCredPassword(credentials credToUpdate)
        {
            return _dataFromSql.UpdateAccountPassword(credToUpdate);
        }

        [HttpDelete("{id}")]
        public bool DeleteCred(int id)
        {
            return _dataFromSql.DeleteTrackById(id);
        }

    }
}