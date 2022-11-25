using Internet_banking.Core.Application.Dtos.Account;
using Internet_banking.Core.Application.Enums;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using Internet_banking.Infrastucture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_banking.Infrastucture.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICuentaRepository _icuentaRepository;

        private readonly IEmailService _emailService;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService, ICuentaRepository cuentaRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _icuentaRepository = cuentaRepository;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No hay cuentas con {request.Email}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Credenciales no validas {request.Email}";
                return response;
            }
            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Cuenta no confirmada para {request.Email}";
                return response;
            }

            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;

            return response;
        }

        public async Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, String origin)
        {
            RegisterResponse response = new()
            {
                HasError = false
            };

            var ExistUserName = await _userManager.FindByNameAsync(request.UserName);
            if (ExistUserName != null)
            {
                response.HasError = true;
                response.Error = $"Usuario '{request.UserName}' ya esta en uso.";
                return response;
            }

            var ExistMail = await _userManager.FindByEmailAsync(request.Email);
            if (ExistMail != null)
            {
                response.HasError = true;
                response.Error = $"Email '{request.Email}' ya esta en uso.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                LastName = request.LastName,
                FirstName = request.FirstName,
                PhoneNumber = request.Phone
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                var verificacion = await SendVerificationEmailUri(user, origin);
                await _emailService.SendAsync(new Core.Application.Dtos.Email.EmailRequest()
                {
                    To = user.Email,
                    Body = $"Por favor valide su cuenta ingresando a URL {verificacion}",
                    Subject = "Confirm registration"
                });
            }
            else
            {
                response.HasError = true;
                response.Error = "Ha ocurrido un error al momento del registro.";
                return response;
            }

            return response;
        }
        public async Task<string> ConfirmAccountAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return $"No hay cuentas registradas con este usuario";
            }

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return $"Cuenta confirmada para {user.Email}. ahora puedes disfrutar de nuestra app.";
            }
            else
            {
                return $"Ha ocurrido un error durante la confirmacion de {user.Email}.";
            }
        }

        public async Task DesactiveUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.EmailConfirmed = false;
                await _userManager.UpdateAsync(user);
            }

        }

        public async Task ActiveUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin)
        {
            ForgotPasswordResponse response = new()
            {
                HasError = false
            };

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No existe cuenta registrada o activa con {request.Email}";
                return response;
            }

            var verificationUri = await SendForgotPasswordUri(user, origin);

            await _emailService.SendAsync(new Core.Application.Dtos.Email.EmailRequest()
            {
                To = user.Email,
                Body = $"Por favor cambie su password visitando URL {verificationUri}",
                Subject = "reestablecer password"
            });


            return response;
        }

        private async Task<string> SendVerificationEmailUri(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "User/ConfirmEmail";
            var Uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "token", code);

            return verificationUri;
        }

        private async Task<string> SendForgotPasswordUri(ApplicationUser user, string origin)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "User/ResetPassword";
            var Uri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(Uri.ToString(), "token", code);

            return verificationUri;
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            ResetPasswordResponse response = new()
            {
                HasError = false
            };

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No hay cuentas registradas con {request.Email}";
                return response;
            }

            request.Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Ha ocurrido un error al intentar cambiar la clave";
                return response;
            }

            return response;
        }


        public async Task<List<UserViewModel>> GetAllUserAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("Basic");
            List<UserViewModel> svm = new();
            if (users != null)
            {
                foreach (var user in users)
                {
                    svm.Add(new UserViewModel()
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        EmailConfirmed = user.EmailConfirmed,
                        UserName = user.UserName
                    });
                }
            }
            return svm;
        }

        public async Task<SaveUserViewModel> UpdateUserAsync(SaveUserViewModel svm)
        {
            ApplicationUser appliUser = await _userManager.FindByIdAsync(svm.Id);
            SaveUserViewModel sv = new();

            if (svm.Password != svm.ConfirmPassword)
            {
                sv.HasError = true;
                sv.Error = "Las contraseñas nuevas no coinciden";
                return sv;
            }

            appliUser.FirstName = svm.FirstName; 
            appliUser.LastName = svm.LastName;
            appliUser.PhoneNumber = svm.Phone;
            appliUser.Cedula = svm.Cedula;
            appliUser.Email=svm.Email;
            appliUser.UserName = svm.Username;

            await _userManager.UpdateAsync(appliUser);

            return sv;
        }

        public async Task<SaveUserViewModel> GetUser(string Id)
        {
            ApplicationUser appliUser = await _userManager.FindByIdAsync(Id);
            if (appliUser != null)
            {
                SaveUserViewModel sv = new()
                {
                    FirstName = appliUser.FirstName,
                    LastName= appliUser.LastName,
                    Email = appliUser.Email,
                    Phone= appliUser.PhoneNumber,
                    Username=appliUser.UserName,
                    Cedula = appliUser.Cedula

                };

                return sv;
            }

            return null;
        }

        public async Task<SaveUserViewModel> CreateCuentaPrincipal(string email,double monto)
        {
            var user = await _userManager.FindByEmailAsync(email);
            int numerocuenta = _icuentaRepository.generarcuenta();
            Cuenta addcount = new()
            {
                Balance = monto,
                EsPrincipal = true,
                Tipo="Ahorro",
                UserId=user.Id,
                NumeroCuenta= numerocuenta
            };

            await _icuentaRepository.AddAsync(addcount);
            SaveUserViewModel temp = new()
            {
                Email = user.Email,
                Cedula=user.Cedula,
                FirstName=user.FirstName,
                LastName = user.LastName,
                Phone=user.PhoneNumber,
                Username = user.UserName,
            };




            return temp;
        }



    }
}
