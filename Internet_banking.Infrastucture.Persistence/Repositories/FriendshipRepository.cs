using Internet_banking.Infrastructure.Persistence.Repository;
using System;
using Internet_banking.Core.Application.Interfaces.Repositories;
using System.Collections.Generic;
using Internet_banking.Core.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internet_banking.Infrastructure.Persistence.Contexts;

namespace Internet_banking.Infrastucture.Persistence.Repositories
{
    public class FriendshipRepository : GenericRepository<Friendship>, IFriendshipRepository
    {
        private readonly ApplicationContext _dbContext;

        public FriendshipRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Friendship>> GetBywithRelationship(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
