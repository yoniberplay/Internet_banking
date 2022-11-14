using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel,User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<UserViewModel> GetByIdViewModel(int id);

        Task<UserViewModel> Restorepass(ForgotPassViewModel fm);
        Task<UserViewModel> GetByusernameViewModel(String fm);
    }
}
