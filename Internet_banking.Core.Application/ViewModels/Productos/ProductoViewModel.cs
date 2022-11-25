using Internet_banking.Core.Application.ViewModels.BaseCommon;
using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Product
{
    public class ProductoViewModel : AuditableBaseViewModel
    {
        public int TipoProducto { get; set; }
        public string NombreTipoProducto { get; set; }
        public bool EsPrincipal { get; set; }
        public string NoProducto { get; set; }
        public int IdUsuario { get; set; }

        // nulleables
        public double? LimiteMontoTarjeta { get; set; }
        public double? MontoPrestamo { get; set; }
        public BeneficiariosViewModel? Beneficiario { get; set; }
    }
}
