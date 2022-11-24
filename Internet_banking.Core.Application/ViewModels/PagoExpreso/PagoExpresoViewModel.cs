using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.PagoExpreso
{
    public class PagoExpresoViewModel
    {
        public int NumeroCuenta { get; set; }
        public double Monto { get; set; }
        public int Cuenta { get; set; }
        public int BeneficiarioId { get; set; }
        public BeneficiariosViewModel Beneficiarios { get; set; }

    }
}
