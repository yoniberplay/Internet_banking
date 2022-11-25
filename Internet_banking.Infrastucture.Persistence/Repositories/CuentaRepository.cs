using Microsoft.EntityFrameworkCore;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Domain.Entities;
using Internet_banking.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internet_banking.Core.Application.ViewModels.Cuenta;

namespace Internet_banking.Infrastructure.Persistence.Repository
{
    public class CuentaRepository : GenericRepository<Cuenta>, ICuentaRepository
    {
        private readonly ApplicationContext _dbContext;

        public CuentaRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int generarcuenta()
        {
            List<int> Numbers = new List<int>();
            Numbers.Add(9); 
            Numbers.Add(6);
            Numbers.Add(0);

            Random rnd = new Random();

            String numero = "960";
            for (int i = 0; i < 6; i++)
            {
                numero += Convert.ToString(rnd.Next(0, 9));

            }

            int numVal = Int32.Parse(numero);

            return numVal;
        }

        public Task UpdateAsync(SaveCuentaViewModel saveCuentaViewModel, int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
