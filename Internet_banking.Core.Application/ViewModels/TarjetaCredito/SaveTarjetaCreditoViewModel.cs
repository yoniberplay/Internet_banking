using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.TarjetaCredito
{
    public class SaveTarjetaCreditoViewModel
    {
        [Required(ErrorMessage = "Especifique el id del usuario")]
        [DataType(DataType.Text)]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Especifique monto credito que tendra disponible")]
        [DataType(DataType.Text)]
        public double CreditDisponible { get; set; }
        public double Debito { get; set; } = 0.00;
        [Required(ErrorMessage = "Especifique limite de la tarjeta")]
        [DataType(DataType.Text)]
        public double Limite { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
