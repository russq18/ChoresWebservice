using ChoresAPI.DataBase;
using ChoresAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ChoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructor and fields for DI
        public DBConnection DBConnection { get; }
        public UserController(Microsoft.Extensions.Options.IOptions<DBConnection> connection)
        {
            DBConnection = connection.Value;
        }
        #endregion

        [HttpGet("GetUsers")]
        [Authorize]
        public ObservableCollection<User> GetUsers()
        {
            var list = DatabaseHelper.GetUsers(DBConnection.DefaultConnection);
            return list;
        }

        [HttpPost("CreateUsers")]
        [Authorize]
        public IActionResult CreateUser([FromBody]User user)
        {
            var message = DatabaseHelper.CreateUser(DBConnection.DefaultConnection,user.FullName,user.Birthday);
            return new ObjectResult(message);
        }

        [HttpPatch("UpdateUser")]
        [Authorize]
        public IActionResult UpdateUser([FromBody]User user)
        {
            var message = DatabaseHelper.UpdateUser(DBConnection.DefaultConnection,user);
            return new ObjectResult(message);
        }
    }
}