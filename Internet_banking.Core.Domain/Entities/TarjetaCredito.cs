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
        public double Credit { get; set; }
        public double Debit { get; set; }
        public double Limit { get; set; }
    }
}
