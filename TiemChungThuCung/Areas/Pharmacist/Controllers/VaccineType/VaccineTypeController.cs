using Models.DataAccessLayer.VaccineDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser;

namespace TiemChungThuCung.Areas.Pharmacist.Controllers.VaccineType
{
    public class VaccineTypeController : Controller
    {
        // GET: Pharmacist/VaccineType
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Pharmacist" });
        }

        public ActionResult List()
        {
            List<vaccine_type> models = new List<vaccine_type>();
            models = new VaccineTypeDAL().GetAllVaccineType();
            return View(models);    
        }

        [HttpPost]
        public ActionResult List(List<vaccine_type> models, string SubmitButton) 
        {
            if(ModelState.IsValid) 
            {
                new VaccineTypeDAL().EditVaccineType(models.Where(m => m.vaccine_code == SubmitButton).FirstOrDefault(), SubmitButton);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                return View(models);
            }
        }

        public ActionResult Add()
        {
            vaccine_type model = new vaccine_type();
            return View(model);
        }


        [HttpPost]
        public ActionResult Add(vaccine_type model)
        {
            if (ModelState.IsValid)
            {
                if (new VaccineTypeDAL().CheckIfVaccineCodeIsExist(model.vaccine_code))
                {
                    ModelState.AddModelError("vaccine_code", "Mã Vaccine đã tồn tại");
                    return View(model);
                }
                else
                {
                    new VaccineTypeDAL().AddVaccineType(model);
                    TempData["Success"] = "Thêm thành công";
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng kiểm tra lại dữ liệu nhập");
                return View(model);
            }
        }

        public ActionResult Delete(string VaccineCode) 
        {
            if(new VaccineTypeDAL().CheckIfVaccineCodeIsExist(VaccineCode)) 
            {
                new VaccineTypeDAL().DeleteVaccineType(VaccineCode);
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
        }
    }
}