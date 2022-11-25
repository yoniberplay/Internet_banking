using Internet_banking.Core.Application.ViewModels.PagoExpreso;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface IPagoExpresoService :  IGenericService<SavePagoExpresoViewModel, PagoExpresoViewModel, PagoExpreso>
    {
    }
}
