using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Pharmacist.Controllers
{
    public class HomeController : PharmacistBaseController
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}