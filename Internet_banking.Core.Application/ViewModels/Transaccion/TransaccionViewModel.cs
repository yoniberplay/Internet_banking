using Internet_banking.Core.Application.ViewModels.BaseCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Transaccion
{
    public class TransaccionViewModel : AuditableBaseViewModel
    {
        public int Origen { get; set; }
        public int Destino { get; set; }
        public int IdUsuarioOrigen { get; set; }
        public int IdUsuarioDestinatario { get; set; }
        public double Monto { get; set; }
        public string Tipo { get; set; }
    }
}
