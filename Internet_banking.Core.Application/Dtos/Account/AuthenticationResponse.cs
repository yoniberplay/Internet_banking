using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Dtos.Account
{
    public class AuthenticationResponse
    {

        public String Id { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }

        public List<String> Roles { get; set; }

        public bool IsVerified { get; set; }
        public bool HasError { get; set; }
        public String Error { get; set; }

    }
}
