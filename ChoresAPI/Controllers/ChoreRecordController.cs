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
    public class ChoreRecordController : ControllerBase
    {
        #region Constructor and fields for DI
        public DBConnection DBConnection { get; }
        public ChoreRecordController(Microsoft.Extensions.Options.IOptions<DBConnection> connection)
        {
            DBConnection = connection.Value;
        }
        #endregion

        [HttpGet("GetRecord")]
        [Authorize]
        public IActionResult GetRecord([FromBody]ChoreRecord record)
        {
            var message = $"Get Call for {nameof(GetRecord)}";
            return new ObjectResult(message);
        }

        [HttpPost("CreateRecord")]
        [Authorize]
        public IActionResult CreateRecord([FromBody]ChoreRecord record)
        {
            var message = DatabaseHelper.CreateRecord(DBConnection.DefaultConnection, record);
            return new ObjectResult(message);
        }

        [HttpPost("UpdateRecord")]
        [Authorize]
        public IActionResult UpdateRecord([FromBody]ChoreRecord record)
        {
            var message = DatabaseHelper.UpdateChoreRecord(DBConnection.DefaultConnection, record);
            return new ObjectResult(message);
        }
    }
}