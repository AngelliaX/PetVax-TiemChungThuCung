using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Client.Controllers
{
    public class HomeController : ClientBaseController
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}