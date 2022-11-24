using Microsoft.AspNetCore.Mvc;
using WebApp.Internet_banking.Middlewares;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Application.Dtos.Account;
using Internet_banking.Core.Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Internet_banking.Core.Application.Interfaces.Services;

namespace Internet_banking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdmUsersController : Controller
    {
        private readonly IUserService _userService;

        public AdmUsersController(IUserService userService)
        {
            _userService = userService;
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Index()
        {
            ViewBag.listausuarios = 555555;
            return View();
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Register()
        {
            return View(new SaveUserViewModel());
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var origin = Request.Headers["origin"];
            RegisterResponse response = await _userService.RegisterAsync(vm, origin);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        //added
        public IActionResult Update()
        {
            return View();
        }

        public IActionResult UserProduts()
        {
            return View();
        }


    }
}
