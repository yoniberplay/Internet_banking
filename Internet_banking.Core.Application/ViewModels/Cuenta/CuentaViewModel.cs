using Internet_banking.Core.Application.ViewModels.BaseCommon;
using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Cuenta
{
    public class CuentaViewModel : AuditableBaseViewModel
    {
        public double Balance { get; set; }
        public string UserId { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public int BeneficiarioId { get; set; }
        public List<BeneficiariosViewModel> Beneficiarios { get; set; }
    }
}
