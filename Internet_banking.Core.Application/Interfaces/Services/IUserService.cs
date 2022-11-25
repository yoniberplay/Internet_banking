using Internet_banking.Core.Application.Dtos.Account;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Internet_banking.Core.Application.Interfaces.Services
{
    public interface IUserService 
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task SignOutAsync();
        Task<List<UserViewModel>> GetAllUser();
        Task<SaveUserViewModel> FindById(String Id);
        Task<SaveUserViewModel> UpdateUserAsync(SaveUserViewModel svm);
        Task DesactiveUser(string id);
        Task ActiveUser(string id);
        Task<SaveUserViewModel> CreateCuentaPrincipal(string email, double monto);
    }
}
