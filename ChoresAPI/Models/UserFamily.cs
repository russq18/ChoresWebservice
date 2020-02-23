using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoresAPI.Models
{
    public class UserFamily
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string FamilyId { get; set; }
    }
}
