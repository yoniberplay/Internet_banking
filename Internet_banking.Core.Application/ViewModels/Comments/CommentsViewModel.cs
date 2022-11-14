using Internet_banking.Core.Application.ViewModels.Post;
using Internet_banking.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.ViewModels.Comments
{
    public class CommentsViewModel
    {

        public String? Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }


        public UserViewModel? User { get; set; }
        public PostViewModel? Post { get; set; }

    }
}
