﻿using AspNetCoreIdentity.Web.Extensions;
using AspNetCoreIdentity.Web.Models;
using AspNetCoreIdentity.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreIdentity.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var userViewModel = new UserViewModel
            {
                Email = currentUser!.Email,
                Username = currentUser!.UserName,
                PhoneNumber = currentUser!.PhoneNumber
            };
            return View(userViewModel!);
        }
        public async Task<IActionResult> PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var checkOldPasssword = await _userManager.CheckPasswordAsync(currentUser,request.PasswordOld);
            if (!checkOldPasssword)
            {
                ModelState.AddModelError(String.Empty, "Eski şifreniz doğru değil.");
                return View();
            }
            var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser,request.PasswordOld,request.PasswordNew);
            if (!resultChangePassword.Succeeded)
            {
                ModelState.AddModelErrorList(resultChangePassword.Errors.Select(x => x.Description).ToList());
                return View();
            }
            TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirilmiştir.";
            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(currentUser, request.PasswordNew,true,false);

            return View();
        }
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();

        }
        public async Task<IActionResult> UserEdit()
        {
            var currentUser = (await _userManager.FindByNameAsync(User!.Identity!.Name!))!;
            var userEditViewModel = new UserEditViewModel()
            {
                Username = currentUser.UserName!,
                Email = currentUser.Email!,
                Phone = currentUser.PhoneNumber!,
             
                City = currentUser.City!,
                Gender = currentUser.Gender!,
          

            };
            
            return View(userEditViewModel);
        }
    }
}
