using Models.DataAccessLayer;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Client.Models;
using TiemChungThuCung.Areas.CommonUse;
namespace TiemChungThuCung.Areas.Client.Controllers
{
    public class PetController : ClientBaseController
    {
        // GET: Client/Pet
        [HttpGet]
        public ActionResult Index()
        {
            return View(getPetInfoModel());
        }

        [HttpPost]
        public ActionResult Index(PetInfoModel model)
        {

            if (!string.IsNullOrEmpty(model.petNameCreation) && !string.IsNullOrEmpty(model.chosenBreedId))
            {
                PetDAO petDAO = new PetDAO();
                petDAO.addNewPet(User.Identity.Name, model.petNameCreation, model.chosenBreedId);
            }

            PetInfoModel userModel = getPetInfoModel();
            userModel.pet_id = model.pet_id;
            model.petNameCreation = "";

            int temp = 0;
            foreach(var pet in userModel.listPet)
            {
                if (pet.pet_id == model.pet_id)
                {
                    userModel.pet_name = pet.pet_name;
                    userModel.breed_name = userModel.listPet_breedName[temp];
                    PetDocumentCommonUse petdoc = new PetDocumentCommonUse();
                    userModel.petDocuments = petdoc.getPetDocument(model.pet_id); 
                    userModel.weight = pet.weight ?? 0;
                    userModel.age = pet.age ?? 0;
                }
                temp++;
            }
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View(getPetInfoModel());
        }

        [HttpPost]
        public ActionResult Update(PetInfoModel model)
        {
            //Trace.WriteLine("petid, updateName, updateAge: " + model.pet_id + ", " + model.updateName + ", " + model.updateAge);
            if (model.updateName != null)
            {
                Trace.WriteLine("Update called");
                PetDAO petDAO = new PetDAO();
                petDAO.updatePet(model.pet_id, model.updateName, model.updateAge, model.updateWeight);

            }

            PetInfoModel userModel = getPetInfoModel();
            userModel.pet_id = model.pet_id;

            int temp = 0;
            foreach (var pet in userModel.listPet)
            {
                if (pet.pet_id == model.pet_id)
                {
                    Trace.WriteLine("foreach called");
                    userModel.updateName = pet.pet_name;
                    userModel.breed_name = userModel.listPet_breedName[temp];
                    userModel.updateWeight = pet.weight ?? 0;
                    userModel.updateAge = pet.age ?? 0;
                }
                temp++;
            }
            
            //Trace.WriteLine("===============================");
            return View(userModel);
        }

        private PetInfoModel getPetInfoModel()
        {
            PetInfoModel model = new PetInfoModel();
            PetDAO petDAO = new PetDAO();
            model.listPet = petDAO.getList_PetbyUsername(User.Identity.Name);
            model.listPet_breedName = petDAO.getList_BreedNamebyPetList(model.listPet);
            List<breed> breeds = petDAO.getAllBreed();
            if (breeds.Count > 1)
            {
                foreach(var item in breeds)
                {
                    model.breedIdforDropbox.Add(item.breed_id);
                    model.breedNameforDropbox.Add(item.breed_name);
                }
            }

            return model;
        }

    }
}