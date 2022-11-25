using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Cuenta
{
    public class SaveProductoViewModel
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Ingresar el tipo producto")]
        [Range(0, int.MaxValue)]
        [DataType(DataType.Text)]
        public int TipoProducto { get; set; }
        public bool EsPrincipal { get; set; }
        public string NoProducto { get; set; }
        public int IdUsuario { get; set; }

        public double? LimiteMontoTarjeta { get; set; }
        public double? MontoPrestamo { get; set; }
    }
}
