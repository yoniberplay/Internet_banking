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
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el monto para la apertura de la cuenta")]
        [DataType(DataType.Text)]
        public double Balance { get; set; }
        [Required(ErrorMessage = "Debe colocar el Id del propietario")]
        [DataType(DataType.Text)]
        public string UserId { get; set; }
        public bool IsPrincipal { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
    }
}
