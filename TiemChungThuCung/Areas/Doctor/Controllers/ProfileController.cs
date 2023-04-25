using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Models.DataAccessLayer;
using Models.EntityFramework;
using TiemChungThuCung.Areas.CommonUse;
using TiemChungThuCung.Areas.Doctor.Models;
using TiemChungThuCung.Models;

namespace TiemChungThuCung.Areas.Doctor.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            ProfileCommonUse profileCommonUse = new ProfileCommonUse();
            UpdateProfileModel model = profileCommonUse.retrieveViewBagProfileDatabyUsername(username);
            return View(model);
        }
        [HttpGet]
        public ActionResult Update()
        {
            string username = User.Identity.Name;
            ProfileCommonUse profileCommonUse = new ProfileCommonUse();
            UpdateProfileModel model = profileCommonUse.retrieveViewBagProfileDatabyUsername(username);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UpdateProfileModel model)
        {
            ProfileCommonUse profileCommonUse = new ProfileCommonUse();

            profileCommonUse.UpdateProfile(User.Identity.Name, model);
            TempData["SuccessMessage"] = "Cập nhật thông tin thành công";

            UpdateProfileModel updateModel = profileCommonUse.retrieveViewBagProfileDatabyUsername(User.Identity.Name);

            if (!string.IsNullOrEmpty(model.newpassword) && !string.IsNullOrEmpty(model.oldpassword))
            {
                var AccountDAO = new AccountDAO();
                bool isSuccessPasswordChanged = AccountDAO.updatePassword(User.Identity.Name, model.oldpassword, model.newpassword);
                if (isSuccessPasswordChanged)
                {
                    TempData["SuccessChangepassword"] = "Đổi mật khẩu thành công";
                }
                else
                {
                    TempData["FailedChangepassword"] = "Sai mật khẩu cũ";
                }
            }
            return View(updateModel);
        }

        [HttpGet]
        public ActionResult Profession()
        {
            return View(getBasicModelonDisplay());
        }

        [HttpGet]
        public ActionResult ProfessionUpdate()
        {
            
            return View(getBasicModelonDisplay());
        }

        [HttpPost]
        public ActionResult ProfessionUpdate(ProfessionModel model)
        {           
            string username = User.Identity.Name;
            DoctorDAO doctorDAO = new DoctorDAO();

            doctorDAO.updateProfession(username,model.education,model.experience,model.chosenBreed_id);
            TempData["SuccessMessage"] = "Thay đổi nghiệp vụ thành công";
            return View(getBasicModelonDisplay());
        }

        private ProfessionModel getBasicModelonDisplay()
        {
            string username = User.Identity.Name;
            DoctorDAO doctorDAO = new DoctorDAO();
            PetDAO petDAO = new PetDAO();

            ProfessionModel model = new ProfessionModel();
            model.breed_id = petDAO.getAllBreedID_asString() ?? new List<string>();
            model.breed_name = new List<string>();
            model.education = doctorDAO.getEducationbyUsername(username) ?? "";
            model.experience = doctorDAO.getExperiencebyUsername(username) ?? "";

            model.chosenBreed_id = doctorDAO.getListBreed_ID_ProfessionbyUsername(username);

            foreach (var item in model.breed_id)
            {
                model.breed_name.Add(doctorDAO.getBreedNamebyId(item));
            }
            return model;
        }
    }
}