using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoresAPI.DataBase;
using ChoresAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        public DBConnection DBConnection { get; }
        public FamilyController(Microsoft.Extensions.Options.IOptions<DBConnection> connection)
        {
            DBConnection = connection.Value;
        }


        [HttpPost("CreateFamily")]
        [Authorize]
        public IActionResult CreateFamily([FromBody]Family family)
        {
            var message = DatabaseHelper.CreateFamily(DBConnection.DefaultConnection, family);
            return new ObjectResult(message);
        }

        [HttpPatch("UpdateFamily")]
        [Authorize]
        public IActionResult UpdateFamily([FromBody]Family family)
        {
            var message = DatabaseHelper.UpdateFamily(DBConnection.DefaultConnection, family);
            return new ObjectResult(message);
        }
    }
}