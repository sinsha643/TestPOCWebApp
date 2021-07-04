using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPOCWebApp.Models
{
    public class UserDetail
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
    }
}
