using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Models;
using MeiFarmWebApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MeiFarmWebApi.Responses;

namespace MeiFarmWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }




        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
                return Forbid(ModelState.Select(x => x.Value + ",").ToString());
            }
            /* if (!user.EmailConfirmed)
             {
                 ModelState.AddModelError(string.Empty, "Confirm your email first");
                 return View();
             }*/

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: rememberMe, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login");
                return View();
            }

            return Forbid("Nothing to show!");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("getUser")]
        public async Task<DefaultResponse> GetUser([FromBody]string id)
        {
            var response = new DefaultResponse { Success = true };

            var user = await _userManager.FindByIdAsync(id);
            //response.User = _mapper.Map<UserModel>(user);
            if (user == null)
            {
                response.Message = "Nothing founded";
            }
            else
            {
                var answer = user.FirstName + user.LastName + user.UserName;
                response.Message = answer;
            }
            return await Task.FromResult<DefaultResponse>(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string repassword)
        {
            if (password != repassword)
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return Forbid();
            }

            var newUser = new UserModel
            {
                UserName = email,
                Email = email
            };

            var userCreationResult = await _userManager.CreateAsync(newUser, password);
            if (!userCreationResult.Succeeded)
            {
                foreach (var error in userCreationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var tokenVerificationUrl = Url.Action("VerifyEmail", "Account", new { id = newUser.Id, token = emailConfirmationToken }, Request.Scheme);

            //await _messageService.Send(email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");

            return Content("Check your email for a verification link");
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Content("Check your email for a password reset link2");

            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetUrl = Url.Action("ResetPassword", "Account", new { id = user.Id, token = passwordResetToken }, Request.Scheme);

            // await _messageService.Send(email, "Password reset", $"Click <a href=\"" + passwordResetUrl + "\">here</a> to reset your password");

            //return Content("Check your email for a password reset link");
            return Content(passwordResetToken);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, string token, string password, string repassword)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException();

            if (password != repassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match");
                return View();
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, password);
            if (!resetPasswordResult.Succeeded)
            {
                foreach (var error in resetPasswordResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            return Content("Password updated");
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public string GetAllAccess()
        {
            return "Hahah";
        }

        [Authorize]
        [HttpPost]
        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            return "Logout was successfull";
        }
    }
}
