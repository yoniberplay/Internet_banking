using AutoMapper;
using Internet_banking.Core.Application.Dtos.Email;
using Internet_banking.Core.Application.Helpers;
using Internet_banking.Core.Application.Interfaces.Repositories;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Internet_banking.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel,UserViewModel,User>,IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailservice;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEmailService emailservice ,IMapper mapper):base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _emailservice = emailservice;
            _mapper =  mapper;
        }

        public async Task<UserViewModel> Login(LoginViewModel vm)
        {
            UserViewModel userVm = new();
            User user = await _userRepository.LoginAsync(vm);

            if(user == null)
            {
                return null;
            }
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> GetByIdViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return _mapper.Map<UserViewModel>(user); 

        }

        public async Task<UserViewModel> Restorepass(ForgotPassViewModel fm)
        {
            User user = await _userRepository.GetByUsernameAsync(fm.Username);

            UserViewModel vm = _mapper.Map<UserViewModel>(user);
            String Pass = GeneratePass.Generate(10);

            user.Password = PasswordEncryptation.ComputeSha256Hash(Pass);
            _userRepository.UpdateAsync(user,user.Id);
            await _emailservice.SendAsync(new EmailRequest
            {
                To = user.Email,
                From = "YONIBER.ENCARNACION@GMAIL.COM",
                Subject = "Reestablecimiento de contraseña",
                Body = $"<h1>Su contraseña ha sido reestablecida</h1> <p>Su nueva contraseña es: {Pass} </p>"

            });
            return vm;

        }
        public override async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            SaveUserViewModel suvm = await base.Add(vm);
            
            await _emailservice.SendAsync(new EmailRequest
            {
                To = suvm.Email,
                From = "YONIBER.ENCARNACION@GMAIL.COM",
                Subject = "Activacion de Usuario",
                Body = $"<h1>Bienvenido {suvm.Username} a esta Red Social</h1>" +
                "<a href='https://github.com/yoniberplay'><button> Activar Cuenta! </button> </a> "

            });

            return suvm;
        }

        public async Task<UserViewModel> GetByusernameViewModel(string fm)
        {
            User user = await _userRepository.GetByUsernameAsync(fm);

            UserViewModel vm = _mapper.Map<UserViewModel>(user);
            return vm;
        }
    }
}
