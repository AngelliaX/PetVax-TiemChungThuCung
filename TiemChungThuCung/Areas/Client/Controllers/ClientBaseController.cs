using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Client.Controllers
{
    [RouteArea("Client", AreaPrefix = "Client")]
    [RoutePrefix("Home")]
    [Authorize(Roles = "Client")]
    public class ClientBaseController : Controller
    {

    }
}