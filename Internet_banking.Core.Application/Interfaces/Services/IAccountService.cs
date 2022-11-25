using Internet_banking.Core.Application.Dtos.Account;
using Internet_banking.Core.Application.ViewModels.User;

namespace Internet_banking.Core.Application.Interfaces.Services 
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task SignOutAsync();
        Task<List<UserViewModel>> GetAllUserAsync();
        Task<SaveUserViewModel> UpdateUserAsync(SaveUserViewModel sv);
        Task<SaveUserViewModel> GetUser(String Id);
        Task DesactiveUser(string id);
        Task ActiveUser(string id);
        Task<SaveUserViewModel> CreateCuentaPrincipal(string email,double monto); 


    }
}