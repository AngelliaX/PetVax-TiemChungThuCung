using Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Client.Controllers;

namespace TiemChungThuCung.Areas.Doctor.Controllers
{
    public class HomeController : DoctorBaseController
    {
        // GET: Doctor/Home
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            AccountDAO accountDAO = new AccountDAO();
            string name = accountDAO.getNamebyUsername(username);
            ViewBag.Name = name;
            return View();
        }
    }
}