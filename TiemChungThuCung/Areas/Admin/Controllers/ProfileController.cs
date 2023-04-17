using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DataAccessLayer;
using Models.EntityFramework;
using TiemChungThuCung.Areas.CommonUse;
using TiemChungThuCung.Models;
namespace TiemChungThuCung.Areas.Admin.Controllers
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
    }
}