using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added
using Internet_banking.Core.Domain.Common;

namespace Internet_banking.Core.Domain.Entities
{
    public class Producto : AuditableBaseEntity
    {
        public int TipoProducto { get; set; }
        public bool EsPrincipal { get; set; }
        public string NoProducto { get; set; }
        public int IdUsuario { get; set; }

        // nulleables
        public double? LimiteMontoTarjeta { get; set; }
        public double? MontoPrestamo { get; set; }

        // Navigation Property
        public Beneficiarios? Beneficiario { get; set; }
    }
}
