using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoresAPI.Models
{
    public class ChoreRecord
    {
        public string Id { get; set; }
        public bool IsDone { get; set; }
        public string DatePerformed { get; set; }
        public string ChoreId { get; set; }
        public string LocationId{ get; set; }
        public string FamilyId { get; set; }
        public string UserId { get; set; }
    }
}
