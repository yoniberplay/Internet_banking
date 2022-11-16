using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Application.ViewModels.Friendship;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Application.Helpers;

namespace Internet_banking.Core.Application.Services
{
    public class FriendshipService : GenericService<SaveFriendViewModel, FriendshipViewModel, Friendship>, IFriendshipService
    {
        private readonly IFriendshipRepository _ifriendRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel? userViewModel;
        private readonly IMapper _mapper;

        public FriendshipService(IFriendshipRepository ifriendRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(ifriendRepository, mapper)
        {
            _ifriendRepository = ifriendRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            _mapper = mapper;
        }

        public async Task<List<FriendshipViewModel>> GetAllFriends()
        {
            var userList = await _ifriendRepository.GetAllAsync();
            userList = userList.Where(f => f.IdUser == userViewModel.Id).OrderByDescending(p => p.Created).ToList();

            return _mapper.Map<List<FriendshipViewModel>>(userList);
        }
    }
}
