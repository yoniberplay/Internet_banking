﻿using WebApp.Internet_banking.Middlewares;
using Internet_banking.Core.Application.ViewModels.User;
using Internet_banking.Core.Application.Dtos.Account;
using Internet_banking.Core.Application.Interfaces.Services;
using Internet_banking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Internet_banking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdmUsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<AdmUsersController> _logger;

        public AdmUsersController(IUserService userService, ILogger<AdmUsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.listausuarios = await _userService.GetAllUser();

            return View();

        }

        public IActionResult Register()
        {
            return View(new SaveUserViewModel());
        }

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
            return RedirectToRoute(new { controller = "AdmUsers", action = "Index" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        //added
        public async Task<IActionResult> Update(String Id)
        {
            SaveUserViewModel sv = await _userService.FindById(Id);

            return View(sv);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveUserViewModel svm)
        {
            if (!ModelState.IsValid)
            {
                return View(svm);
            }

            SaveUserViewModel updateStatus = await _userService.UpdateUserAsync(svm);
            if (updateStatus.HasError)
            {
                return View(svm);
            }
            return RedirectToRoute(new { controller = "AdmUsers", action = "Index" });
        }




        public IActionResult UserProduts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
