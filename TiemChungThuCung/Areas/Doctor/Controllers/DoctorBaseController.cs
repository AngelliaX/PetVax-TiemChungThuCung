using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Doctor.Controllers
{
    [RouteArea("Doctor", AreaPrefix = "Doctor")]
    [RoutePrefix("Home")]
    [Authorize(Roles = "Doctor")]
    public class DoctorBaseController : Controller
    {
    }
}