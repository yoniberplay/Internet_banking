using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Domain.Entities;
using Internet_banking.Infrastructure.Persistence.Contexts;
using Internet_banking.Infrastructure.Persistence.Repository;

namespace Internet_banking.Infrastucture.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comments>, ICommentRepository
    {
        public CommentRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
