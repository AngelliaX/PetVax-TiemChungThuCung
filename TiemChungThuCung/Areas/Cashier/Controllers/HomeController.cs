using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Cashier.Controllers
{
    public class HomeController : CashierBaseController
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}