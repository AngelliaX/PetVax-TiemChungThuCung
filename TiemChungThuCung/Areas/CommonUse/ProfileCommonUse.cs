using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DataAccessLayer;
using Models.EntityFramework;
using TiemChungThuCung.Models;

namespace TiemChungThuCung.Areas.CommonUse
{
    public class ProfileCommonUse : Controller
    {
        public UpdateProfileModel retrieveViewBagProfileDatabyUsername(string username)
        {
            var AccountDAO = new AccountDAO();
            account account = AccountDAO.getAccountbyUsername(username);

            UpdateProfileModel updateProfileModel = new UpdateProfileModel();
            updateProfileModel.username = "N/A";
            updateProfileModel.name = "N/A";
            updateProfileModel.email = "N/A";
            updateProfileModel.phone = "N/A";
            updateProfileModel.address = "N/A";
            updateProfileModel.birthday = new DateTime(1, 1, 1);
            if (account != null)
            {
                DateTime? birthday = account.birthday;
                updateProfileModel.username = account.username;
                updateProfileModel.name = account.name ?? "N/A";
                updateProfileModel.email = account.email ?? "N/A";
                updateProfileModel.phone = account.phone ?? "N/A";
                updateProfileModel.address = account.address ?? "N/A";
                updateProfileModel.birthday = birthday;
            }

            return updateProfileModel;
        }

        public void UpdateProfile(string username, UpdateProfileModel model)
        {
            string name = model.name;
            string email = model.email;
            string phone = model.phone;
            string address = model.address;
            DateTime? birthday = model.birthday;
            var AccountDAO = new AccountDAO();
            AccountDAO.updateAccountProfile(username, name, email, phone, address, birthday);
        }
    }
}