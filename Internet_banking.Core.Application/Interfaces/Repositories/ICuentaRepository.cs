using Internet_banking.Core.Application.ViewModels.Cuenta;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Repositories
{
    public interface ICuentaRepository : IGenericRepository<Cuenta>
    {
        Task UpdateAsync(SaveCuentaViewModel saveCuentaViewModel, int accountNumber);
    }
}
