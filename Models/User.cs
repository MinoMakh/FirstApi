using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Models
{
    public class User
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}