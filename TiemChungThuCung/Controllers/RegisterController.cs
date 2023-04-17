using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Models;
using Models.DataAccessLayer;

namespace TiemChungThuCung.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var AccountDAO = new AccountDAO();
                if (AccountDAO.isUsernameExisted(model.username))
                {
                    ViewBag.FailedAttempt = "Tên đăng nhập đã tồn tại";
                }
                else
                {
                    AccountDAO.insertNewAccount(model.username, model.password);
                    TempData["SuccessMessage"] = "Tạo thành công tài khoản " + model.username;
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {

            }
            return View();
        }

    }
}