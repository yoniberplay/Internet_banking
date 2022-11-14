using Microsoft.EntityFrameworkCore;
using Internet_banking.Core.Application.Helpers;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using Internet_banking.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;

namespace Internet_banking.Infrastructure.Persistence.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<User> GetByUsernameAsync(string? username)
        {
            var temp = await _dbContext.Set<User>().Where(u => u.Username == username).ToListAsync();
            return temp.First();
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);
            User user = await _dbContext.Set<User>().FirstOrDefaultAsync(user=> user.Username == loginVm.Username && user.Password == passwordEncrypt);
            return user;
        }

    }
}
