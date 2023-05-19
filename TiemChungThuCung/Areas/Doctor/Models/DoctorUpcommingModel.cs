using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityFramework;
namespace TiemChungThuCung.Areas.Doctor.Models
{
    public class DoctorUpcommingModel
    {
        public DoctorUpcommingModel()
        {
            apps = new List<appointment>();
            pets = new List<pet>();
            accs = new List<account>();
            breednames = new List<string>();
            petDocuments = new List<string>();

            All_apps = new List<appointment>();
            All_pets = new List<pet>();
            All_accs = new List<account>();
            All_breednames = new List<string>();
            All_petDocuments = new List<string>();

            //List<pet_vaccine> tmp = new List<pet_vaccine>();
            pet_vacc = new List<List<pet_vaccine>>();
            correspond_vaccine_name = new List<List<string>>();

            updatePetVacc = new List<pet_vaccine> { };
            for (int i = 0; i < 100; i++)
            {
                updatePetVacc.Add(new pet_vaccine());
            }
        }

        //Display of specialist appointment, used for Index + Upcomming
        public List<appointment> apps { get; set; }
        public List<pet> pets { get; set; }
        public List<string> breednames { get; set; }
        public List<string> petDocuments { get; set; }
        public List<account> accs { get; set; }
        //========================================

        //Display of ALL appointment, used for Index
        public List<appointment> All_apps { get; set; }
        public List<pet> All_pets { get; set; }
        public List<string> All_breednames { get; set; }
        public List<string> All_petDocuments { get; set; }
        public List<account> All_accs { get; set; }
        //========================================

        //HttpPost in Index(), used to detect the chosen app then 
        public string chosen_appointmentId { get; set; }
        //========================================

        //HttpGet & HttpPost in Upcomming() 
            //- Hồ sơ vaccine
        public List<List<pet_vaccine>> pet_vacc { get; set; }
        public List<List<string>> correspond_vaccine_name { get; set; }

        public List<string> Data_vaccineId { get; set; }
        public List<string> Data_vaccineName { get; set; }

            // -Thêm lịch tiêm
        public string petIdtoAddVaccine { get; set; }
        public string vaccineIdtoAdd { get; set; }
        public int doseNumber { get; set; }
        public DateTime vaccineDateToJab{ get; set; }

        public string remainModalId { get; set; }

            // -Xóa petvac
        public int pet_vaccIdtoRemove { get; set; }
            // -Update petvac
        public List<pet_vaccine> updatePetVacc{ get; set; }

        //========================================

    }
}