using AutoMapper;
using Microsoft.AspNetCore.Http;
using Internet_banking.Core.Application.Helpers;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Application.ViewModels.Comments;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Services
{
    public class CommentService : GenericService<SaveCommentViewModel, CommentsViewModel, Comments>,  ICommentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel? userViewModel;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IHttpContextAccessor httpContextAccessor, IMapper mapper, ICommentRepository commentRepository) : base(commentRepository, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public override async Task<SaveCommentViewModel> Add(SaveCommentViewModel vm)
        {
            vm.UserId = userViewModel.Id;

            return await base.Add(vm);
        }

        public override async Task Update(SaveCommentViewModel vm, int id)
        {
            vm.UserId = userViewModel.Id;

            await base.Update(vm,id);
        }


    }
       
    }
    
