using Internet_banking.Core.Application.ViewModels.BaseCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Prestamo
{
    public class PrestamoViewModel : AuditableBaseViewModel
    {
        public string UserId { get; set; }
        public double MontoPrestamo { get; set; }
        public double MontoPagado { get; set; }
        public bool PagadoTotal { get; set; }
    }
}
