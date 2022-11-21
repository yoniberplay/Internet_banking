using Microsoft.AspNetCore.Http;
using Internet_banking.Core.Application.Helpers;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Application.Dtos.Account;

namespace Internet_banking.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }

    }
}
