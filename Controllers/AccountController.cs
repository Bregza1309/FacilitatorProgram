using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FacilitatorProgram.Models.ViewModels;
namespace FacilitatorProgram.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> UserManager;
        SignInManager<IdentityUser> SignInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public ViewResult Login()
        {
            ViewData["mode"] = "Login";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityUser User = await UserManager.FindByNameAsync(model.UserName);
                if (User == null)
                {
                    ModelState.AddModelError("","Username does not exist");
                }
                else
                {
                    var result =  (await SignInManager.PasswordSignInAsync(User, model.Password, false, false));
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Incorrect Password");
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
            }
            ViewData["mode"] = "Login";
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {

            ViewData["mode"] = "Register";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords don't match");
            }
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new() { UserName = model.UserName };

                IdentityResult result =  await UserManager.CreateAsync(newUser, model.Password);
                if (!result.Succeeded)
                {
                    foreach(IdentityError err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
                else
                {
                    return Redirect("/Account/Login");
                }
            }
            ViewData["mode"] = "Register";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            
            await SignInManager.SignOutAsync();
            return Redirect("/Account/Login");
        }
    }
}
