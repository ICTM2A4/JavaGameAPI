using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaGameAPI.DTO.Authentication
{
    public class AuthenticateUser
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
