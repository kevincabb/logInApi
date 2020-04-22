using System.Collections.Generic;
using login.Models;
using login.Services;
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

        [HttpPost]
        public int AddCred(credentials credToAdd)
        {
            //Take credToAdd
        }
    }
}