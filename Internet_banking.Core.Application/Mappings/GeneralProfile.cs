using AutoMapper;
using Internet_banking.Core.Application.ViewModels.Comments;
using Internet_banking.Core.Application.ViewModels.Post;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Application.ViewModels.Friendship;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region mapeo de users
            CreateMap<User, UserViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<User, SaveUserViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ForMember(dest => dest.Post, opt => opt.Ignore())
               .ForMember(dest => dest.Friendship, opt => opt.Ignore());
            #endregion

            #region mapeo de post
            CreateMap<Post, PostViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Post, SavePostViewModel>()
                .ForMember(dest => dest.File, opt => opt.Ignore())
                .ForMember(dest => dest.NuevoComentario, opt => opt.Ignore())
                .ForMember(dest => dest.Idpost, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region mapeo de comments
            CreateMap<Comments, CommentsViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Comments, SaveCommentViewModel>()
               .ReverseMap()
               .ForMember(dest => dest.User, opt => opt.Ignore())
               .ForMember(dest => dest.Post, opt => opt.Ignore())
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region mapeo de Amistad
            CreateMap<Friendship, FriendshipViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Friendship, SaveFriendViewModel>()
                 .ForMember(dest => dest.amigo, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(dest => dest.Created, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModified, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion


        }
    }
}
