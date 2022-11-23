using Internet_banking.Core.Application.ViewModels.BaseCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.TarjetaCredito
{
    public class TarjetaCreditoViewModel : AuditableBaseViewModel
    {
        public string UserId { get; set; }
        public double CreditDisponible { get; set; }
        public double Debito { get; set; }
        public double Limite { get; set; }
        public string Tipo { get; set; }
    }
}
