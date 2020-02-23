using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoresAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreRecordController : ControllerBase
    {
        [HttpGet("anyone")]
        public IActionResult GetRecord([FromBody]ChoreRecord record)
        {
            var message = $"Get Call for {nameof(GetRecord)}";
            return new ObjectResult(message);
        }

        [HttpPost("anyone")]
        public IActionResult CreateUser([FromBody]User user)
        {
            var message = $"Post Call for {nameof(CreateUser)}";
            return new ObjectResult(message);
        }

        [HttpPatch("anyone")]
        public IActionResult UpdateUser([FromBody]User user)
        {
            var message = $"Patch Call for {nameof(UpdateUser)}";
            return new ObjectResult(message);
        }
    }
}