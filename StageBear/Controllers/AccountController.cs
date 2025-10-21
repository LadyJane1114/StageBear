using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace StageBear.Controllers
{
    public class AccountController : Controller
    {

        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        //POST: /Account/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            // validated username and password
            if (Username == _configuration["sb_username"] && Password == _configuration["sb_password"])
            {
                // Create a list of claims identifying the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, Username), // unique ID
                    new Claim(ClaimTypes.Name, "Lady Jane"), // human readable name
                    //new Claim(ClaimTypes.Role, "Smuggler"), // could use roles if needed         
                };

                // Create the identity from the claims
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign-in the user with the cookie authentication scheme
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                //   IDEALLY WE WANT TO REDIRECT THEM BACK TO THE PAGE THEY WERE ON, BUT RIGHT NOW WE'RE NOT SURE HOW YET. WILL TROUBLESHOOT LATER.


                return RedirectToAction("Index","Home");
            }
            else
            {
                //should make it so that it'll say which one perhaps?
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }


        // GET: /Account/Logout
        public IActionResult Logout()
        {
            return View();
        }

        //POST: /Account/Logout
        public async Task<IActionResult> LogoutConfirmed()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Goodbye","Account"); //redirect to /Account/Goodbye
        }

        public IActionResult Goodbye()
        {
            return View();
        }

        public IActionResult ReturnToLogin()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
