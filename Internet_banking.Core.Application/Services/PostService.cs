using AutoMapper;
using Microsoft.AspNetCore.Http;
using Internet_banking.Core.Application.Helpers;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Application.ViewModels.Post;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>,IPostService
    {
        private readonly IPostRepository _ipostRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel? userViewModel;
        private readonly IMapper _mapper;

        public PostService(IPostRepository ipostRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(ipostRepository, mapper)
        {
            _ipostRepository = ipostRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _mapper = mapper;
        }

        public override async Task<SavePostViewModel> Add(SavePostViewModel vm)
        {
            vm.UserId = userViewModel.Id;

            return await base.Add(vm);
        }

        public override async Task Update(SavePostViewModel vm, int id)
        {
            vm.UserId = userViewModel.Id;

            await base.Update(vm, id);
        }

       
        public async Task<List<PostViewModel>> GetAllMyPost()
        {
            var mypostlist = await _ipostRepository.GetAllAsync();

            mypostlist = mypostlist.Where(p => p.UserId == userViewModel.Id).OrderByDescending(p => p.Created).ToList(); 

            return _mapper.Map<List<PostViewModel>>(mypostlist);
        }

        Task<PostViewModel> IPostService.GetPostsandDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PostViewModel>> GetAllMyFriendPost()
        {
            var mypostlist = await _ipostRepository.GetAllAsync();

            mypostlist = mypostlist.Where(p => p.UserId != userViewModel.Id).OrderByDescending(p => p.Created).ToList();
            
            return _mapper.Map<List<PostViewModel>>(mypostlist);
        }

        public async Task<List<PostViewModel>> GetAllMyFriendPost(int friendid)
        {
            var mypostlist = await _ipostRepository.GetAllAsync();

            mypostlist = mypostlist.Where(p => p.UserId == friendid).OrderByDescending(p => p.Created).ToList();

            return _mapper.Map<List<PostViewModel>>(mypostlist);
        }

    }
}
