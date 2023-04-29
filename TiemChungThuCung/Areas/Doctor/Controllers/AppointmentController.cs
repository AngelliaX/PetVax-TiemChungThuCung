using Models.DataAccessLayer;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Client.Controllers;
using TiemChungThuCung.Areas.Doctor.Models;

namespace TiemChungThuCung.Areas.Doctor.Controllers
{
    public class AppointmentController : DoctorBaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            
            return View(getIndexModel());
            
        }

        [HttpPost]
        public ActionResult Index(DoctorUpcommingModel model)
        {
            AppointmentDAO appDAO = new AppointmentDAO();

            appointment chosenApp = appDAO.getAppointmentById(model.chosen_appointmentId);
            if (chosenApp.state == 0 || chosenApp == null)
            {
                appDAO.setDoctorforApp(model.chosen_appointmentId, User.Identity.Name);
                @TempData["SuccessMessage"] = "Nhận đơn thành công, hãy vào mục Sắp Tới";
            }
            else
            {
                @TempData["FailedMessage"] = "Đơn vừa có cập nhật mới, thao tác không thành công!";
            }
            
            return View(getIndexModel());
        }

        private DoctorUpcommingModel getIndexModel()
        {
            DoctorUpcommingModel model = new DoctorUpcommingModel();

            AppointmentDAO appDAO = new AppointmentDAO();
            PetDAO petDAO = new PetDAO();
            AccountDAO accDAO = new AccountDAO();
            DoctorDAO docDAO = new DoctorDAO();

            //Get specialist apps
            //Todo check function if it works getAll_unOwnedAppointments_FilterSpecialist();
            model.apps = appDAO.getAll_unOwnedAppointments_FilterSpecialist(docDAO.getListBreed_ID_ProfessionbyUsername(User.Identity.Name));
            foreach (var item in model.apps)
            {
                pet pet = petDAO.getPetbyId(item.pet_id);
                model.pets.Add(pet);
                model.breednames.Add(petDAO.getBreedNamebyId(pet.breed_id));
                model.accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }

            //Get ALL apps
            model.All_apps = appDAO.getAll_unOwnedAppointments();
            foreach (var item in model.All_apps)
            {
                pet pet = petDAO.getPetbyId(item.pet_id);
                model.All_pets.Add(pet);
                model.All_breednames.Add(petDAO.getBreedNamebyId(pet.breed_id));
                model.All_accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }
            return model;
        }
        [HttpGet]
        public ActionResult Upcomming()
        {
            return View(getUpcommingModel());
        }

        private DoctorUpcommingModel getUpcommingModel()
        {
            DoctorUpcommingModel model = new DoctorUpcommingModel();

            AppointmentDAO appDAO = new AppointmentDAO();
            PetDAO petDAO = new PetDAO();
            AccountDAO accDAO = new AccountDAO();
            DoctorDAO docDAO = new DoctorDAO();

            model.apps = appDAO.getUpcommingAppointmentsOfDoctorUsername(User.Identity.Name);
            foreach (var item in model.apps)
            {
                pet pet = petDAO.getPetbyId(item.pet_id);
                model.pets.Add(pet);
                model.breednames.Add(petDAO.getBreedNamebyId(pet.breed_id));
                model.accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }
            return model;
        }

        [HttpGet]
        public ActionResult History()
        {
            DoctorUpcommingModel model = new DoctorUpcommingModel();

            AppointmentDAO appDAO = new AppointmentDAO();
            PetDAO petDAO = new PetDAO();
            AccountDAO accDAO = new AccountDAO();
            DoctorDAO docDAO = new DoctorDAO();

            model.apps = appDAO.getFinishedAppointmentsOfDoctorUsername(User.Identity.Name);
            foreach (var item in model.apps)
            {
                pet pet = petDAO.getPetbyId(item.pet_id);
                model.pets.Add(pet);
                model.breednames.Add(petDAO.getBreedNamebyId(pet.breed_id));
                model.accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }
            return View(model);
        }

    }
}