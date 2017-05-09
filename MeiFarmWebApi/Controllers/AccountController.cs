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

namespace MeiFarmWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
       /* 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }*/
    }
}
