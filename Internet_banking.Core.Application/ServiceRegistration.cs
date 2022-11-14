using Internet_banking.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.Interfaces.Services;
using System.Reflection;

namespace Internet_banking.Core.Application
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services,IConfiguration configuration)
        {
            #region Services
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFriendshipService, FriendshipService>();
            #endregion
        }
    }
}
