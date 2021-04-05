using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMonitorREST.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Login()
        {

        }
    }
}
