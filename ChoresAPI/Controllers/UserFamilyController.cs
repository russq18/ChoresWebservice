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
    public class UserFamilyController : ControllerBase
    {
        #region Constructor and fields for DI
        public DBConnection DBConnection { get; }
        public UserFamilyController(Microsoft.Extensions.Options.IOptions<DBConnection> connection)
        {
            DBConnection = connection.Value;
        }
        #endregion

        [HttpPost("CreateUserFamily")]
        [Authorize]
        public IActionResult CreateUserFamily([FromBody]UserFamily userFamily)
        {
            var message = DatabaseHelper.CreateUserFamily(DBConnection.DefaultConnection, userFamily);
            return new ObjectResult(message);
        }

        [HttpPatch("UpdateUserFamily")]
        [Authorize]
        public IActionResult UpdateUserFamily([FromBody]UserFamily userFamily)
        {
            var message = DatabaseHelper.UpdateUserFamily(DBConnection.DefaultConnection, userFamily);
            return new ObjectResult(message);
        }
    }
}