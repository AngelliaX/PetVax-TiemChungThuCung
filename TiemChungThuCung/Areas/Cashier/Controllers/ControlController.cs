using Models.DataAccessLayer.BillDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Cashier.Controllers
{
    public class ControlController : Controller
    {
        // GET: Cashier/Controll
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new {area = "Cashier"});
        }
        public ActionResult BillList()
        { 
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(bill Bill)
        {
            Bill.bill_vaccine.bill_id = Bill.bill_id;
            new BillDAL().AddBill(Bill);
            TempData["AddBillSuccess"] = "Thêm hóa đơn thành công";
            return View();
        }
    }
}