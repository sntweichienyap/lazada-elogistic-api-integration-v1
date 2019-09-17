using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        //api/auth 
        [HttpPost]
        public ActionResult Auth([FromBody]LazadaAuthRequest request)
        {
            var response = new LazadaAuthResponse() { username = request.username, password = request.password };
            if (request != null && request.username != null && request.password != null && request.username.Equals("sntuser") && request.password.Equals("abc123"))
            {
                response.token = "abcdefghijklmnopqrstuvwxy";
                return Ok(response);
            }

            response.message = "Invalid username or password";
            return StatusCode(401, response);
        }
    }

    public class LazadaAuthRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LazadaAuthResponse
    {
        public string token { get; set; }
        public string message { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
