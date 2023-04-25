using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Client.Models
{
    public class PetInfoModel
    {
        public List<pet> listPet { get; set; }
        public List<string> listPet_breedName { get; set; }
        public string client_username { get; set; }
        public string pet_id { get; set; }
        public string breed_name { get; set; }
        public string pet_name { get; set; }
        public int age { get; set; }
        public double weight { get; set; }

        //=For adding new pet========================================
        public List<string> breedIdforDropbox { get; set; }
        public List<string> breedNameforDropbox { get; set; }

        [Required(ErrorMessage = "Hãy điền tên")]
        public string petNameCreation { get; set; }

        [Required(ErrorMessage = "Hãy chọn vai trò")]
        public string chosenBreedId { get; set; }

        //=For updating pet========================================

        public string updateName { get; set; }
        public int updateAge { get; set; }
        public double updateWeight { get; set; }

        public PetInfoModel()
        {
            breedIdforDropbox = new List<string>();
            breedNameforDropbox = new List<string>();
        }
    }
}