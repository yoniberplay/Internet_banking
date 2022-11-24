using Internet_banking.Core.Application.ViewModels.Beneficiarios;
using Internet_banking.Core.Application.ViewModels.Cuenta;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface ICuentaService : IGenericService<SaveCuentaViewModel, CuentaViewModel, Cuenta>
    {
    }
}
