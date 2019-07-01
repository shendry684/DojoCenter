using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DojoCenter.Controllers
{
    public class HomeController : Controller
    {
        private CenterContext context;
        private static PasswordHasher<User> registerHasher = new PasswordHasher<User>();
        private static PasswordHasher<LoginUser> loginHasher = new PasswordHasher<LoginUser>();

        public HomeController(CenterContext cc)
        {
            context = cc;
        }
        public static List<string> shindigs = new List<string>(){};

        public static PasswordHasher<User> RegisterHasher { get => registerHasher; set => registerHasher = value; }
        public static PasswordHasher<LoginUser> LoginHasher { get => loginHasher; set => loginHasher = value; }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
        
            // ViewBag.shindigs = shindigs;
            return View();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Create(User u)
        {
            User userInDb = context.GetUserByEmail(u.Email);
            if(userInDb != null)
            {
                ModelState.AddModelError("Email", "Email already in use!");
            }
            if(ModelState.IsValid)
            {
                u.Password = RegisterHasher.HashPassword(u, u.Password);
                int UserId = context.Create(u);
                HttpContext.Session.SetInt32("UserId", UserId);
                return RedirectToAction("Shindigs");
            }
            return View("Index");
        }

        
        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginUser u)
        {
            User userInDb = context.GetUserByEmail(u.LoginEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LoginEmail", "Unknown Email!");
            }
            if (ModelState.IsValid)
            {
                var result = LoginHasher.VerifyHashedPassword(u, userInDb.Password, u.LoginPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Incorrect!");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                    return RedirectToAction("Shindigs");
                }
            }
            return View("Index");
        }

        [Route("shindigs")]
        [HttpGet]
        public IActionResult Shindigs(Shindig w)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return Redirect("/");
            }
            else
            {
                ViewBag.User = context.GetUserById((int)UserId);
                ViewBag.shindigs = context.Shindigs.Include(sid => sid.Shindigname).ToList();
                ViewBag.Participant = context.Participants;
                Console.WriteLine(context.Participants.Count());
                
                return View();
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [Route("new")]
        [HttpGet]
        public IActionResult ShindigForm()
        {
            return View();
        }

        [Route("shindig")]
        [HttpPost]
        public IActionResult Create(Shindig s)
        {
            
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(ModelState.IsValid)
            {
                s.PlannerId = (int) UserId;
                context.Create(s);
                return Redirect("Shindigs");
            }
            else 
            {
                return View("ShindigForm", s);
            }
        }


        [Route("join/{ShindigId}")]
        [HttpGet]
        public IActionResult join(int ShindigId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            Participant p = new Participant();
            p.ShindigId = ShindigId;
            p.UserId = (int)UserId;
            context.Create(p);
            return Redirect("/shindigs");
        }

        [Route("leave/{ShindigId}")]
        [HttpGet]
        public IActionResult leave(int ShindigId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            context.Remove(ShindigId, (int)UserId);
            return Redirect("/shindigs");
        }

        [Route("delete/{ShindigId}")]
        [HttpPost]
        public IActionResult Delete(int ShindigId)
        {
            context.Remove(ShindigId);
            return Redirect("/shindigs");
        }

        [Route("shindig/{ShindigId}")]
        [HttpPost]
        public IActionResult Click(int ShindigId)
        {
            
            return Redirect("/success");
        }

    }
}


