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
            return View();
        }
    }
}