using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Dtos.Account
{
    public class AuthenticationRequest
    {
        public String Email { get; set; }
        public String Password { get; set; }

    }
}
