using Internet_banking.Core.Application.ViewModels.Cuenta;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Beneficiarios
{
    public class BeneficiariosViewModel
    {
        public int Id { get; set; }
        public string NombreBeneficiario { get; set; }
        public string ApellidoBeneficiarios { get; set; }
        public CuentaViewModel Cuenta { get; set; }
    }
}
