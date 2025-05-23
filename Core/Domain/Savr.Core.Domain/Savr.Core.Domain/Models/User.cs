using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savr.Core.Domain.Models
{
    public class User : ModelBase
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Country { get; set; }
        public required string Email { get; set; }
        public int MobileNumber { get; set; }
        public string[]? Preference { get; set; }
        public bool IsActive { get; set; }
    }
}
