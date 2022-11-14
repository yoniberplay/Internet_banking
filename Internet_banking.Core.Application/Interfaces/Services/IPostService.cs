using Internet_banking.Core.Application.ViewModels.Post;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface IPostService : IGenericService<SavePostViewModel, PostViewModel,Post>
    {
        Task<PostViewModel> GetPostsandDetails(int id);
        Task<List<PostViewModel>> GetAllMyPost();

        Task<List<PostViewModel>> GetAllMyFriendPost(int friendid);

        
    }
}
