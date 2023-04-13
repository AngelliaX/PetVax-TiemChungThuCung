using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Pharmacist.Controllers
{
    [RouteArea("Pharmacist", AreaPrefix = "Pharmacist")]
    [RoutePrefix("Home")]
    [Authorize(Roles = "Pharmacist")]
    public class PharmacistBaseController : Controller
    {

    }
}