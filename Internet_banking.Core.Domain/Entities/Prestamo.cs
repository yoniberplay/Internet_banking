using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Prestamo : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public double MontoPrestamo { get; set; }
        public double MontoPagado { get; set; }
        public bool PagadoTotal { get; set; }
    }
}
