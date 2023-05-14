using Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TiemChungThuCung.Models;
using TiemChungThuCung.MyRoleProvider;

namespace TiemChungThuCung.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            Trace.WriteLine("Index httpget called");
            if (User.Identity.IsAuthenticated)
            {
                Trace.WriteLine("Index redirect called");
                return redirectLogin();
            }
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (Membership.ValidateUser(model.username,model.password) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.username, model.rememberMe);
               
                return redirectLogin();
            }   
            else
            {
                ViewBag.FailedAttempt = "Tên đăng nhập hoặc mật khẩu sai";
            }
            return View(model);
        }
        public RedirectToRouteResult redirectLogin()
        {
            CredentialConstant credentialConstant = new CredentialConstant();
            if (User.IsInRole(credentialConstant.GetRole(0))) //Admin
            {
                Trace.WriteLine("Admin called!");
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else if (User.IsInRole(credentialConstant.GetRole(1))) //Client
            {
                Trace.WriteLine("Client called!");
                return RedirectToAction("Index", "Home", new { area = "Client" });
            }
            else if (User.IsInRole(credentialConstant.GetRole(2))) //Doctor
            {
                Trace.WriteLine("Doctor called!");
                return RedirectToAction("Index", "Home", new { area = "Doctor" });
            }
            else if (User.IsInRole(credentialConstant.GetRole(3))) //Pharmacist
            {
                return RedirectToAction("Index", "Home", new { area = "Pharmacist" });
                }
            else if (User.IsInRole(credentialConstant.GetRole(4))) //Cashier
            {
                return RedirectToAction("Index", "Home", new { area = "Cashier" });
            }
            else
            {
                Trace.WriteLine("Else called!");
                return RedirectToAction("Index", "Login", new { area = "" });
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}