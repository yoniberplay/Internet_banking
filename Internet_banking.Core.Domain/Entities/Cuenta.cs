using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Cuenta : AuditableBaseEntity
    {
        public double Balance { get; set; } = 0.00;
        public string UserId { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public bool EsPrincipal { get; set; }
        public int BeneficiarioId { get; set; }

        //Navigation Property
        public Beneficiarios Beneficiario { get; set; }
    }
}
