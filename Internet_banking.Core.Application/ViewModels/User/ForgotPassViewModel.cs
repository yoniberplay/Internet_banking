using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Internet_banking.Core.Application.ViewModels.User
{
    public class ForgotPassViewModel
    {
        [Required(ErrorMessage = "Debe colocar un nombre de usuario")]
        [DataType(DataType.Text)]
        public string? Username { get; set; }
    }
}
