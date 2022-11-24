using Internet_banking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Domain.Entities
{
    public class Transacciones : AuditableBaseEntity
    {
        public int Origen { get; set; }
        public int Destino { get; set; }
        public double Monto { get; set; }
        public string Tipo { get; set; }

    }
}
