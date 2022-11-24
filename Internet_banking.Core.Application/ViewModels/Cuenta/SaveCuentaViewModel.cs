using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Cuenta
{
    public class SaveCuentaViewModel
    {
        
        public double Balance { get; set; } = 0.00;
        [Required(ErrorMessage = "Debe colocar el Id del propietario")]
        [DataType(DataType.Text)]
        public string UserId { get; set; }
       
        public bool IsPrincipal { get; set; }
    }
}
