using System;
using System.Linq;
using System.Web.Mvc;
using ImageBoard.Models;
using System.IO;
using System.Security.Cryptography;
using System.Web.Security;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using ImageBoard.ViewModel;
using System.Net.NetworkInformation;

namespace ImageBoard.Controllers
{
    [AllowAnonymous]
    public class AccountController : ImageControllerBase
    {
        MainContext _db = new MainContext();
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authentification(SignupLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("BaseLoginForm", model);
            }
            var signup = model.Signup;
            if(signup != null)
                Security.CreateUser(signup);
            User user = new User();
            if (model.Login != null)
            {
                var tempUser = Users.GetBy(model.Login.UserName);
                if (tempUser != null)
                {
                    var Salt = tempUser.Salt;
                    model.Login.Password = Auth.HashFunction(model.Login.Password, Salt);
                    if (Security.Authenticate(model.Login.UserName, model.Login.Password))
                    {
                       
                    }
                }
            }
            
            return RedirectToAction("Index", "Home", new { Id = user.Id });
        }
        public string GetMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        public ActionResult Login(SignupLoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (ValidateUser(model.Login.UserName, model.Login.Password))
                {

                    FormsAuthentication.SetAuthCookie(model.Login.UserName, true);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        int valueId = Convert.ToInt32(Session["Id"]);
                        Response.Cookies["Login"].Value = model.Login.UserName;
                        Response.Cookies["password"].Value = model.Login.Password;
                        return RedirectToAction("Index", "Home", new { Id = valueId });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            if (Session["Id"] != null)
            {
                Session["Id"] = null;
                Session.Abandon();
            }
              
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        public JsonResult CheckUserName(string username)
        {
            MainContext _db = new MainContext();
            var result = _db.Users.Find(username).UserName.Count() == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //===============[Созданные функции для понятного кода]======================
        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;

            using (MainContext _db = new MainContext())
            {
                try
                {
                    if (Request.Cookies["Password"] != null)
                    {
                        password = Request.Cookies["Password"].Value;
                    }
                    else
                    {
                        var Salt = (from u in _db.Users where u.UserName == login select u.Salt).FirstOrDefault();
                        password = Auth.HashFunction(password, Salt);
                        Response.Cookies["Password"].Value = password;
                    }
                        
                    var user = (from u in _db.Users
                                where u.UserName == login && u.Password == password
                                select u).FirstOrDefault();
                    if (user != null)
                    {
                        isValid = true;
                        Session["Id"] = Convert.ToString(user.Id);
                    }
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}
