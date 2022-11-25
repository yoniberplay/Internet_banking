using Internet_banking.Core.Application.ViewModels.BaseCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Prestamo
{
    public class SavePrestamoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Especifique el id del usuario que tomara el prestamos")]
        [DataType(DataType.Text)]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Ingrese monto total del prestamo")]
        [DataType(DataType.Text)]
        public double MontoPrestamo { get; set; }
        public double MontoPagado { get; set; } = 0.00;
        public bool PagadoTotal { get; set; } = false;
    }
}
