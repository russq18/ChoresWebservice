using ChoresAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace ChoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("anyone")]
        public IActionResult GetUser([FromBody]User user)
        {
            var message = $"Get Call for {nameof(GetUser)}";
            return new ObjectResult(message);
        }
        [HttpGet("anyone")]
        public ObservableCollection<User> GetUsers([FromBody]UserFamily userFamily)
        {
            var result = new ObservableCollection<User>();
            var message = $"Get Call for {nameof(GetUsers)}";
            result.Add(new User { FullName = message });
            return result;
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