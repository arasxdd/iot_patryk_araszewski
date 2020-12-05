using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HatChat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HatChat.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private const string UsernameKey = "USER_NAME_KEY";

        [HttpGet("signin")]
        public IActionResult signIn()
        {
            return View(new SignInVm());
        }

        [HttpPost("signin")]
        public IActionResult signIn(SignInVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            HttpContext.Session.SetString(UsernameKey, vm.Username);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString(UsernameKey);

            if (string.IsNullOrEmpty(username)) return RedirectToAction("signIn");

            ViewData["Username"] = username;
            return View();
            
        }
    }
}
