using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckAPI.JWT
{
    public class AuthRequest
    {
        public string UserName { get; set; } = "username";
        public string Password { get; set; } = "password";
    }
}
