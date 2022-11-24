using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Infrastucture.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Cedula { get; set; }
    }
}
