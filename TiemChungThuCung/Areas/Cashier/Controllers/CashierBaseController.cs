using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Cashier.Controllers
{
    [RouteArea("Cashier", AreaPrefix = "Cashier")]
    [RoutePrefix("Home")]
    [Authorize(Roles = "Cashier")]
    public class CashierBaseController : Controller
    {

    }
}