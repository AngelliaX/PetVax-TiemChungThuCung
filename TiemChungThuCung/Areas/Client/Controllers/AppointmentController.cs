using Models.DataAccessLayer;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Client.Models;
namespace TiemChungThuCung.Areas.Client.Controllers
{
    public class AppointmentController : ClientBaseController
    {
        public ActionResult Index()
        {
            return View("Create");
        }

        [HttpGet]
        public ActionResult Upcomming()
        {
            string username = User.Identity.Name;
            UpcommingModel model = new UpcommingModel();
            PetDAO petDAO = new PetDAO();
            AppointmentDAO appDAO = new AppointmentDAO();
            AccountDAO accDAO = new AccountDAO();
            DoctorDAO docDAO = new DoctorDAO();

            List<pet> pets = petDAO.getList_PetbyUsername(username);
            model.apps = appDAO.getAllAppointmentsfromPetList(pets);
            foreach (var item in model.apps)
            {
                model.petname.Add(petDAO.getPetNamebyId(item.pet_id));
                model.accs.Add(accDAO.getAccountbyUsername(item.doctor_username));
                model.docs.Add(docDAO.getDoctorbyUsername(item.doctor_username));
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateAppointmentModel createAppointmentModel = getBasicModel();

            return View(createAppointmentModel);
        }

        [HttpPost]
        public ActionResult Create(CreateAppointmentModel model)
        {

            AppointmentDAO appointmentDAO = new AppointmentDAO();
            appointmentDAO.insertNewAppointment(model.chosenPetID, model.date, model.note);

            CreateAppointmentModel createAppointmentModel = getBasicModel();
            createAppointmentModel.chosenPetID = "";
            createAppointmentModel.note = "";
            TempData["SuccessMessage"] = "Thêm thành công cuộc hẹn !";
            return RedirectToAction("Create");
        }

        private CreateAppointmentModel getBasicModel()
        {
            CreateAppointmentModel createAppointmentModel = new CreateAppointmentModel();

            AccountDAO accountDAO = new AccountDAO();
            createAppointmentModel.account = accountDAO.getAccountbyUsername(User.Identity.Name);

            PetDAO petDAO = new PetDAO();
            createAppointmentModel.listPet = petDAO.getList_PetbyUsername(User.Identity.Name);

            return createAppointmentModel;
        }
    }
}