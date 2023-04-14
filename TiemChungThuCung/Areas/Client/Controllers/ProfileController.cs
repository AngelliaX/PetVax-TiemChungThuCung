using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Client.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Client/Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
    }
}