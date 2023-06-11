using Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Admin.Models;
using TiemChungThuCung.MyRoleProvider;
namespace TiemChungThuCung.Areas.Admin.Controllers
{
    public class ControlController : Controller
    {
        // GET: Admin/Control
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Doctor" });
        }

        public ActionResult Statistic()
        {
            var statisticDAO = new StatisticDAO();
            var model = statisticDAO.ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateStaffAccount()
        {
            CreateStaffAccountModel model = new CreateStaffAccountModel();
            model.username = "";
            model.password = "";
            model.account_type = 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateStaffAccount(CreateStaffAccountModel model)
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

                    AccountDAO.insertNewAccount(model.username, model.password, model.account_type);
                    CredentialConstant credentialConstant = new CredentialConstant();
                    ViewBag.SuccessMessage = "Tạo tài khoản " + model.username + "với vai trò" + credentialConstant.GetRole(model.account_type) +" thành công!";
                }

            }
            else
            {
                ModelState.AddModelError("", "Hãy kiểm tra lại các yêu cầu");
            }
            Trace.WriteLine("Info: " + model.username + "," + model.password + "," + model.account_type);
            // do something with the data...
            
            CreateStaffAccountModel modelNew = new CreateStaffAccountModel();
            model.username = "";
            model.password = "";
            model.account_type = 1;
            return View(modelNew);

        }
    }
}