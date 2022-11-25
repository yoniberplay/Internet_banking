using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.PagoExpreso
{
    public class SavePagoExpresoViewModel
    {
        public int Id { get; set; }
        [Required]
        // for numbers that need to start with a zero
        [RegularExpression("([0-9]+)", ErrorMessage = "Introduce un numero de cuenta valido")]
        [Range(10, 30, ErrorMessage = "El numero de cuenta ha de ser entre 10 a 30")]
        public int NumeroCuenta { get; set; }

        [Required]
        [Range(10, 1000000, ErrorMessage = "No se permiten transacciones nulas")]
        public double Monto { get; set; }
        [Required]

        // for numbers that need to start with a zero
        [RegularExpression("([0-9]+)", ErrorMessage = "Introduce un numero de cuenta valido")]
        [Range(10, 30, ErrorMessage = "El numero de cuenta ha de ser entre 10 a 30")]
        public int Cuenta { get; set; }

        public int BeneficiarioId { get; set; }
    }
}
