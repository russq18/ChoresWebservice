using ChoresAPI.DataBase;
using ChoresAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ChoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DBConnection DBConnection { get; }
        public UserController(Microsoft.Extensions.Options.IOptions<DBConnection> connection)
        {
            DBConnection = connection.Value;
        }



        [HttpGet("anyone")]
        public ObservableCollection<User> GetUsers()
        {
            var list = DatabaseHelper.GetUsers(DBConnection.DefaultConnection);
            return list;
        }

        //[HttpPost("anyone")]
        //public IActionResult CreateUser([FromBody]User user)
        //{
        //    var message = $"Post Call for {nameof(CreateUser)}";
        //    return new ObjectResult(message);
        //}

        //[HttpPatch("anyone")]
        //public IActionResult UpdateUser([FromBody]User user)
        //{
        //    var message = $"Patch Call for {nameof(UpdateUser)}";
        //    return new ObjectResult(message);
        //}
    }
}