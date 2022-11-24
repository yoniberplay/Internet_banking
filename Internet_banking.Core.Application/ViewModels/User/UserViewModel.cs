using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Id { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public String UserName { get; set; }
        public String Cedula { get; set; }
    }
}
