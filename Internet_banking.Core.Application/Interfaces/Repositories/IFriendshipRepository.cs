using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internet_banking.Core.Domain.Entities;

namespace Internet_banking.Core.Application.Interfaces.Repositories
{
    public interface IFriendshipRepository : IGenericRepository<Friendship>
    {
        Task<List<Friendship>> GetBywithRelationship(int userid);

    }
}
