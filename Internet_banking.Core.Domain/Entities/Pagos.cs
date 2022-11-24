using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Pagos : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public double Monto { get; set; }
    }
}
