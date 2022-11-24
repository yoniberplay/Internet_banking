using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Dtos.Account
{
    public class RegisterRequest
    {
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String ConfirmPassword { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }

    }
}
