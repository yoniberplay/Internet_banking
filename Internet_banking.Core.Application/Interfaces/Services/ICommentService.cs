using Internet_banking.Core.Application.ViewModels.Comments;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface ICommentService : IGenericService<SaveCommentViewModel, CommentsViewModel,Comments>
    {
      
    }
}
