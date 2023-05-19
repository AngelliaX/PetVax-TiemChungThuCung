using Models;
using Models.DataAccessLayer.VaccineDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiemChungThuCung.Areas.Pharmacist.Controllers
{
    public class ControlController : Controller
    {
        // GET: Pharmacist/Control
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Pharmacist" });
        }
        public ActionResult DetailVaccineForm(string LotNumber)
        {
            vaccine_lot model = new VaccineLotDAL().GetVaccineLotByLotNumber(LotNumber);
            return View(model);
        }
        public ActionResult VaccineList()
        {
            List<vaccine_lot> model = new VaccineLotDAL().GetAllVaccineLot();
            return View(model);
        }
        public ActionResult Edit(string LotNumber)
        {
            vaccine_lot model = new VaccineLotDAL().GetVaccineLotByLotNumber(LotNumber);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(vaccine_lot lot)
        {
            
            if (ModelState.IsValid)
            {
                if (lot.remain_amount > lot.total_amount)
                {
                    ModelState.AddModelError("remain_amount", "SL còn lại không được lớn hơn tổng SL");
                    return View(lot);
                }    
                else if (lot.expiration_date < lot.production_date)
                {
                    ModelState.AddModelError("expiration_date", "HSD không được bé hơn NSX");
                    return View(lot);
                }
                else if (lot.rival_date < lot.production_date)
                {
                    ModelState.AddModelError("rival_date", "Ngày nhập không được bé hơn NSX");
                    return View(lot);
                }
                else
                {
                    new VaccineLotDAL().EditVaccineLot(lot, lot.lot_number);
                    return RedirectToAction("VaccineList");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                return View(lot);
            }

        }
        public ActionResult Add()
        {
            vaccine_lot model = new vaccine_lot();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(vaccine_lot lot)
        {
            lot.remain_amount = lot.total_amount;
            if (ModelState.IsValid)
            {
                if(new VaccineLotDAL().GetVaccineLotByLotNumber(lot.lot_number) != null) 
                {
                    ModelState.AddModelError("lot_number", "Số lô đã tồn tại");
                    return View(lot);
                }
                if (lot.remain_amount > lot.total_amount)
                {
                    ModelState.AddModelError("remain_amount", "SL còn lại không được lớn hơn tổng SL");
                    return View(lot);
                }
                else if (lot.expiration_date < lot.production_date)
                {
                    ModelState.AddModelError("expiration_date", "HSD không được bé hơn NSX");
                    return View(lot);
                }
                else if (lot.rival_date < lot.production_date)
                {
                    ModelState.AddModelError("rival_date", "Ngày nhập không được bé hơn NSX");
                    return View(lot);
                }
                else if (lot.rival_date > lot.expiration_date)
                {
                    ModelState.AddModelError("rival_date", "Ngày nhập không được lớn hơn HSD");
                    return View(lot);
                }
                else
                {
                    new VaccineLotDAL().AddVaccineLot(lot);
                    return RedirectToAction("VaccineList");
                }
            }
            else
            {
                ModelState.AddModelError("","Vui lòng kiểm tra lại dữ liệu nhập");
                return View(lot);
            }
        }
        public ActionResult Delete(string LotNumber)
        {
            new VaccineLotDAL().DeleteVaccineLot(LotNumber);
            return RedirectToAction("VaccineList");
        }
        
    }
}