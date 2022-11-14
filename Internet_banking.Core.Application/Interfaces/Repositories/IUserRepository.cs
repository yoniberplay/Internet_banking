using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel loginVm);
        Task<User> GetByUsernameAsync(string? username);
    }
}
