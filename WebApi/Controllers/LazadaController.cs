using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class LazadaStatusUpdateRequest
    {
        public string tracking_number { get; set; }
    }

    public class LazadaStatusUpdateResponse
    {
        public string message { get; set; }
        public string status_code { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LazadaController : ControllerBase
    {
        [HttpPost]
        public ActionResult StatusUpdate([FromBody]LazadaStatusUpdateRequest request)
        {
            if (request != null && request.tracking_number.Equals("abc123"))
                return StatusCode(202);

            return UnprocessableEntity(new LazadaStatusUpdateResponse()
            {
                message = "Tracking number not found",
                    status_code="422",
            }
            );

                //return new LazadaStatusUpdateResponse()
                //{
                //    message = "Tracking number not found",
                //     status_code="422",
                // };
            }
    }
}
