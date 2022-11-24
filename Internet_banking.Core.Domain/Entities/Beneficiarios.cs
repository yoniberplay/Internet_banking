using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Beneficiarios : AuditableBaseEntity
    {
        public string NombreBeneficiario { get; set; }
        public string ApellidoBeneficiarios { get; set; }
        public int CuentaID { get; set; }
        public Cuenta? Cuenta { get; set; }
    }
}
