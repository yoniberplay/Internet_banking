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
        public double LoanAmount { get; set; }
        public double AmountPaid { get; set; }
        public double Share { get; set; }
        public bool IsPaid { get; set; }
    }
}
