using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;
using System.Diagnostics;
namespace Models.DataAccessLayer
{
    public class PetDAO
    {
        private TiemChungThuCungDbContext context = null;
        public PetDAO()
        {
            context = new TiemChungThuCungDbContext();
        }

        public List<pet> getList_PetbyUsername(string username)
        {
            var list = context.pets.Where(a => a.client_username == username).ToList();
            return list;
        }

        public List<string> getList_BreedNamebyPetList(List<pet> petList)
        {
            List<string> breedNameList = petList.Select(pet => getBreedNamebyId(pet.breed_id)).ToList();
            return breedNameList;
        }

        public string getBreedNamebyId(string breed_id)
        {
            var breed = context.breeds.FirstOrDefault(b => b.breed_id == breed_id);
            string name = "No Data Found";
            if (breed != null)
            {
                name = breed.breed_name;
            }
            return name;
        }

        public string getPetNamebyId(string id)
        {
            var pet = context.pets.FirstOrDefault(p => p.pet_id == id);
           
            string result = "No Data Found";
            if (pet != null)
            {
                result = pet.pet_name;
            }
            return result;
        }

        public List<breed> getAllBreed()
        {
            var breeds = context.breeds.ToList();
            return breeds;
        }

        public List<string> getAllBreedID_asString()
        {
            var breeds = context.breeds.Select(b => b.breed_id).ToList();
            return breeds;
        }

        public void addNewPet(string username, string petname, string breed_id)
        {
            var pet = new pet();
            string lastestPetID = getLatestPetIdonTable();
            pet.pet_id = CommonUseDAO.getTextPart(lastestPetID) + (CommonUseDAO.getNumberPart(lastestPetID)+1).ToString();
            pet.breed_id = breed_id;
            pet.client_username = username;
            pet.pet_name = petname;
            context.pets.Add(pet);
            context.SaveChanges();
        }

        public void updatePet(string pet_id,string name, int age, double weight)
        {
            pet pet = context.pets.FirstOrDefault(a => a.pet_id == pet_id);
            if (pet != null)
            {
                pet.pet_name = name;
                pet.age = age;
                pet.weight = weight;
            }
            context.SaveChanges();
        }

        private string getLatestPetIdonTable()
        {
            var pets = context.pets.ToList();

            int lastPetId_Number = 1;
            string lastestPetID = "pet_1";
            foreach (var pet in pets)
            {
                if (CommonUseDAO.getNumberPart(pet.pet_id) > lastPetId_Number)
                {
                    lastestPetID = pet.pet_id;
                    lastPetId_Number = CommonUseDAO.getNumberPart(pet.pet_id);
                }
            }

            return lastestPetID;
        }

    }
}
