using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazadaController : ControllerBase
    {
        //api/lazada 
        [HttpPost]
        public ActionResult StatusUpdate([FromQuery]string token, [FromBody]LazadaStatusUpdateRequest request)
        {
            if (token == null)
                return StatusCode(401, new LazadaStatusUpdateResponse()
                {
                    message = "Token is empty",
                    status_code = "401",
                });

            if (DateTime.Now.Ticks % 2 == 0)
            {
                return StatusCode(401, new LazadaStatusUpdateResponse()
                {
                    message = "Token is expired",
                    status_code = "401",
                });
            }

            if (request != null && request.tracking_number.Equals("abc123"))
                return StatusCode(202);

            return UnprocessableEntity(new LazadaStatusUpdateResponse()
            {
                message = "Tracking number not found",
                status_code = "422",
            }
            );
        }
    }

    public class LazadaStatusUpdateRequest
    {
        public string tracking_number { get; set; }
    }

    public class LazadaStatusUpdateResponse
    {
        public string message { get; set; }
        public string status_code { get; set; }
    }
}
