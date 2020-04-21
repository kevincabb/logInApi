using System.Collections.Generic;
using login.Models;
using login.Services;
using Microsoft.AspNetCore.Mvc;

namespace login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class credentialController: ControllerBase
    {
        readonly DataService _fixedData;
        public credentialController(DataService fixedData)
        {
            _fixedData = fixedData;
        }

        [HttpGet]
        public IEnumerable<credentials> Get()
        {
            return _fixedData.GetCredentials();
        }

        [HttpGet("first")]
        public credentials GetFirstCredentials()
        {
            return _fixedData.GetFirstCredential();
        }
    }
}