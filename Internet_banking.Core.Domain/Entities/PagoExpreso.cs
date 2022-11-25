using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class PagoExpreso : AuditableBaseEntity
    {
        public int NumeroCuenta { get; set; }
        public double Monto { get; set; }
        public int Cuenta { get; set; }
        public int BeneficiarioId { get; set; }
        public Beneficiarios? Beneficiarios { get; set; }
    }
}
