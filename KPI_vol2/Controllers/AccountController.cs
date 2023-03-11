using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using KPI_vol2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace KPI_vol2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IDepartaments departaments;
        private readonly IZgloszenie zgloszenia;
        private readonly ApplicationDbContext db;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger,
            IDepartaments departaments,
            IZgloszenie zgloszenia,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.departaments = departaments;
            this.zgloszenia = zgloszenia;
            this.db = db;
        }

        //get:listOfUsers
        public ViewResult Index()
        {
            return View(userManager.Users);
        }

        public ViewResult ZgloszeniaUzytkownika()
        {
            //var pageNumber = page ?? 1;
            //int pageSize = 10;
            var userId = userManager.GetUserId(User);
            var ogloszenia = zgloszenia.GetAllZgloszenie().Where(x => x.PostedBy.Id == userId);

            if (ogloszenia != null)
            {
                return View(ogloszenia);
            }
            else
            {
                ViewBag.ErrorMessage = $"Użytkowniknie posiada,żadnych ogłoszeń";
                return View();
            }

        }
        public ViewResult ZgloszeniaPrzypisane()
        {
            //var pageNumber = page ?? 1;
            //int pageSize = 10;
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = userManager.GetUserId(User);
            var ogloszenia = zgloszenia.GetAllZgloszenie();

            if (ogloszenia != null)
            {
                return View(ogloszenia);
            }
            else
            {
                ViewBag.ErrorMessage = $"Użytkowniknie posiada,żadnych ogłoszeń";
                return View();
            }

        }

        public ViewResult UserPanel()
        {
            return View();
        }





        // GET: /<controller>/
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            ViewBag.Department = new SelectList(departaments.DepartmentsList(), "Id", "Name");
            return View();
        }
        //[AcceptVerbs("Get", "Post")]
        //[AllowAnonymous]
        //public async Task<IActionResult> IsEmailInUse(string email)
        //{
        //    var user = await userManager.FindByEmailAsync(email);

        //    if (user == null)
        //    {
        //        return Json(true);
        //    }
        //    else
        //    {
        //        return Json($"Email {email} jest już w użyciu, proszę wpisz inny adres.");
        //    }
        //}

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)//sprawdzanie poprawności pól
            {
                var user = new AppUser
                {
                    UserName = registerVM.Email,
                    Email = registerVM.Email,
                    Imie = registerVM.Imie,
                    Nazwisko = registerVM.Nazwisko,
                    DepatmentID=registerVM.DepatmentID
                };// przekazanie wartośći z RegisterVM do IdentityUser
                var result = await userManager.CreateAsync(user, registerVM.Password);// utworzenie użytkownika

                if (result.Succeeded)// jesli operacja zapisu powiodła , nastepuje przekazanie do okna Index kontrolera Home
                {
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))// jesli uzytkownik jest zalogowany jako admin ,
                                                                                  //może utwożyć nowego użytkownika ,nie nastapi jego wylogowanie
                    {
                        return RedirectToAction("ListOfUsers", "Administration");
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);// w przypadku błędów w loginie i haśle pojawiają się błędy 
                    //,które użytkownik musi poprawić
                }
            }
            return View(registerVM);
        }





        /// <summary>
        /// /////////////
        /// </summary>
        /// <returns></returns>

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Copy data from RegisterViewModel to AppUser
        //        var user = new AppUser
        //        {
        //            UserName = model.Email,
        //            Email = model.Email,
        //            PasswordHash=model.Password
        //        };

        //        // Store user data in AspNetUsers database table
        //        var result = await userManager.CreateAsync(user, model.Password);



        //        // If user is successfully created, sign-in the user using
        //        // SignInManager and redirect to index action of HomeController
        //        if (result.Succeeded)
        //        {
        //            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        //            var confirmLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

        //            logger.Log(LogLevel.Warning, confirmLink);

        //            if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
        //            {
        //                return RedirectToAction("ListOfUsers", "Administrator");
        //            }

        //            ViewBag.ErrorTitle = "Rejestracja przebiegła pomyślnie";
        //            ViewBag.ErrorMessage = "Zanim sie zalogujesz prosze potwierdź swój adres email.";

        //            //await signInManager.SignInAsync(user, isPersistent: false);
        //            //return RedirectToAction("index", "home");
        //        }

        //        // If there are any errors, add them to the ModelState object
        //        // which will be displayed by the validation summary tag helper
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    return View(model);
        //}

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} jest juz zajęty.");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return View("ResetPasswordConfirmation");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token = token }, Request.Scheme);

                    // Log the password reset link
                    logger.Log(LogLevel.Warning, passwordResetLink);

                    // Send the user to Forgot Password Confirmation view
                    return View("ForgotPasswordConfirmation");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        public IActionResult UserDetails()
        {
            var users = db.AppUsers.Include(d => d.Departments);

            var userId = userManager.GetUserId(HttpContext.User);
            AppUser user = userManager.FindByIdAsync(userId).Result;
           // var uzyt = db.AppUsers.Include(d => d.Departments);
            return View(user);


            //var user = UserManager.FindById(User.Identity.GetUserId());
            //var userStepsList = db.UserSteps.Where(u => u.UserId == user.Id).Include(u => u.Step).Include(u => u.User);
            //return View(userStepsList);
        }
        public IActionResult UserDetailsII()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            AppUser user = userManager.FindByIdAsync(userId).Result;
            // var uzyt = db.AppUsers.Include(d => d.Departments);
            return View(user);


            //var user = UserManager.FindById(User.Identity.GetUserId());
            //var userStepsList = db.UserSteps.Where(u => u.UserId == user.Id).Include(u => u.Step).Include(u => u.User);
            //return View(userStepsList);
        }


        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Użytkownik o identyfikatorze= {id} nie możezostać odnaleziony";
                return View("NotFound");
            }

            var model = new EditUserVM
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                DepatmentID = user.DepatmentID,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Użytkownik o identyfikatorze= {model.Id} nie możezostać odnaleziony";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Imie = model.Imie;
                user.Nazwisko = model.Nazwisko;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserDetails");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.Error = $" Użytkownik o identyfikatorze nr: {id} nie został odnaleziony.";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    await signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("Index", "Home");
            }


        }

    }
}

