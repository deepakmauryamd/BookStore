using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public ViewResult UserLogin(bool loginFailed = false)
        {
            if(loginFailed)
            {
               ViewBag.Error =  "Username or Password is incorrect";
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Login failed");
            }
            return RedirectToAction(nameof(UserLogin), new {loginFailed = true});
        }

        [HttpGet]
        public ViewResult Registor(bool isRegisterFailed = false, bool isUserExists = false)
        {
            if(isUserExists)
            {
               ViewBag.Error =  "Username or email already exists";
            }
            if(isRegisterFailed)
            {
                ViewBag.Error = "Something's wrong, please fill all the fields.";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registor(UserRegistorModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Username
                };
                
                
                var k = await _userManager.FindByNameAsync(model.Username);
                if(k != null)
                {
                    return RedirectToAction(nameof(Registor), new { isUserExists = true});
                }
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction(nameof(Registor), new { isRegisterFailed = true});
        }

        
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}