using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class TarjetaCredito : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public double CreditDisponible { get; set; }
        public double Debito { get; set; }
        public double Limite { get; set; }
        public string Tipo { get; set; }

    }
}
