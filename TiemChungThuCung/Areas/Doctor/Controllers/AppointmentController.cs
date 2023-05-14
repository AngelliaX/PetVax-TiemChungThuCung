using Models.DataAccessLayer;
using Models.EntityFramework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Doctor.Models;
using TiemChungThuCung.Areas.CommonUse;

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
                model.petDocuments.Add(getPetDocument(item.pet_id));
                model.accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }

            //Get ALL apps
            model.All_apps = appDAO.getAll_unOwnedAppointments();
            foreach (var item in model.All_apps)
            {
                pet pet = petDAO.getPetbyId(item.pet_id);
                model.All_pets.Add(pet);
                model.All_breednames.Add(petDAO.getBreedNamebyId(pet.breed_id));
                model.All_petDocuments.Add(getPetDocument(item.pet_id));
                model.All_accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }
            return model;
        }
        [HttpGet]
        public ActionResult Upcomming()
        {

            return View(getUpcommingModel());
        }

        [HttpPost]
        public ActionResult Upcomming(DoctorUpcommingModel model, string buttonObj = "none")
        {
            VaccineDAO vaccineDAO = new VaccineDAO();
            AppointmentDAO appointmentDAO = new AppointmentDAO();
            if (buttonObj == "addVaccine")
            {                
                vaccineDAO.addVaccineToPet(model.petIdtoAddVaccine,model.vaccineIdtoAdd,model.doseNumber,model.vaccineDateToJab);
                TempData["SuccessMessage" + model.remainModalId] = "Thêm vaccine thành công";
            }else if (buttonObj == "removeVaccine")
            {
                vaccineDAO.removePet_Vaccine(model.pet_vaccIdtoRemove);
                TempData["SuccessMessage" + model.remainModalId] = "<span style=\"color: orangered\">Xóa</span> vaccine thành công";
            }else if (buttonObj == "updateVaccine")
            {
                foreach (var item in model.updatePetVacc)
                {
                    vaccineDAO.syncRecord(item);
                }
                TempData["SuccessMessage" + model.remainModalId] = "Cập nhật thành công";
            }
            else if (buttonObj == "updateAppointment")
            {
                foreach (var app in model.apps)
                {
                    appointmentDAO.syncRecord(app);
                }
                TempData["SuccessUpdateApp"] = "Cập nhật đơn hẹn thành công, xem tại mục Lịch sử";
                model.remainModalId = "";
            }

            DoctorUpcommingModel newModel = getUpcommingModel();
            newModel.remainModalId = "#" + model.remainModalId;
            return View(newModel);
        }

        private DoctorUpcommingModel getUpcommingModel()
        {
            DoctorUpcommingModel model = new DoctorUpcommingModel();

            AppointmentDAO appDAO = new AppointmentDAO();
            PetDAO petDAO = new PetDAO();
            AccountDAO accDAO = new AccountDAO();
            DoctorDAO docDAO = new DoctorDAO();
            VaccineDAO vaccineDAO = new VaccineDAO();
            Trace.WriteLine("Doctor name: " + User.Identity.Name);
            model.apps = appDAO.getUpcommingAppointmentsOfDoctorUsername(User.Identity.Name);
            foreach (var item in model.apps)
            {
                pet pet = petDAO.getPetbyId(item.pet_id);
                model.pets.Add(pet);
                model.breednames.Add(petDAO.getBreedNamebyId(pet.breed_id));
                model.accs.Add(accDAO.getAccountbyUsername(pet.client_username));
                model.petDocuments.Add(getPetDocument(item.pet_id));
            }

            model.Data_vaccineId = vaccineDAO.getList_AllVaccineId();
            model.Data_vaccineName = vaccineDAO.getList_AllVaccineName();

            int temp = 0;
            foreach (var pet in model.pets)
            {
                List<pet_vaccine> list = vaccineDAO.getList_AllPet_VaccineFromPetId(pet.pet_id);
                model.pet_vacc.Add(list);
                model.correspond_vaccine_name.Add(vaccineDAO.getList_VaccineNameFromListPet_vaccine(list));
                temp++;
            }

            return model;
        }

        private string getPetDocument(string petId)
        {
            PetDocumentCommonUse petdoc = new PetDocumentCommonUse();
            return petdoc.getPetDocument(petId);
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
                model.petDocuments.Add(getPetDocument(item.pet_id));
                model.accs.Add(accDAO.getAccountbyUsername(pet.client_username));
            }
            return View(model);
        }

    }
}