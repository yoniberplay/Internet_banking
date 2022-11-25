using Internet_banking.Core.Application.ViewModels.BaseCommon;
using Internet_banking.Core.Application.ViewModels.Cuenta;
using Internet_banking.Core.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Beneficiarios
{
    public class BeneficiariosViewModel : AuditableBaseViewModel
    {
        public string NombreBeneficiario { get; set; }
        public string ApellidoBeneficiarios { get; set; }
        public int NumeroCuenta { get; set; }
        public ICollection<ProductViewModel> Productos { get; set; }
    }
}
