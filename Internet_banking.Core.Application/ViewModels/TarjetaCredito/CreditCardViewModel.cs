using Internet_banking.Core.Application.ViewModels.BaseCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_bankingication.ViewModels.CreditCard
{
    public class CreditCardViewModel : AuditableBaseViewModel
    {
        public string UserId { get; set; }
        public double CreditDisponible { get; set; }
        public double Debito { get; set; }
        public double Limite { get; set; }
    }
}
