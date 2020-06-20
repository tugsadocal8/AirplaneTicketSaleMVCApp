using FlyMvcApp.Identity;
using FlyMvcApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FlyMvcApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

            userManager.PasswordValidator = new CustomPasswordValidator()
            {
                RequiredLength = 7,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireUppercase = true,
                //RequireNonLetterOrDigit = true,
            };

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                var user = userManager.Find(model.Username, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Beklenmeyen giriş tekrar deneyin!");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };

                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);

                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }



        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ForgotPassword(string Email) 
        {

            IdentityDataContext db = new IdentityDataContext(); //instance aldık

            var sorgu = (from i in db.Users where i.Email.Equals(Email) select i).SingleOrDefault(); //üyeyi yakaladık

            if (sorgu != null) //üyevarsa kod yolladık 
            {
                Guid randomkey = Guid.NewGuid(); //32 karakterli kodu ürettik

                sorgu.PasswordHash = randomkey.ToString().Substring(0, 5);///keyi ekleyip veritabanına ekledik

                db.SaveChanges(); //kaydettik

                SmtpClient client = new SmtpClient("mail.server.com");
                MailAddress from = new MailAddress("info@server.com");
                MailAddress to = new MailAddress(sorgu.Email);// userin mailini yazdık
                MailMessage msg = new MailMessage(from, to);
                msg.IsBodyHtml = true;
                msg.Subject = "Şifre Degiştirme İsteği Bildirimi";
                msg.Body += "<h2>  Merhaba " + sorgu.Email + " Şifre Degiştirme İsteğiniz Alınmıştır.  Kodunuz" + randomkey.ToString().Substring(0, 5) + "  Sitemize girerek şifrenizi Güncelleyiniz </h2>  </br>  "; //randomkeyimizi 5 karatere düşdük
                NetworkCredential info = new NetworkCredential("info@server.com", "sifreniz");
                client.Credentials = info;
                client.Send(msg); ///gönderdik

            }

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.Username;
                user.Email = model.Email;

                var result = userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            return View(model);

            
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Login");

        }

    }
}