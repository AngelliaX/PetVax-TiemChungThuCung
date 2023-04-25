using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;
using System.Diagnostics;
namespace Models.DataAccessLayer
{
    public class DoctorDAO
    {
        private TiemChungThuCungDbContext context = null;
        public DoctorDAO()
        {
            context = new TiemChungThuCungDbContext();
        }

        public void updateProfession(string username, string education, string experience, List<string> chosenBreed_ID)
        {
            
            //remove all records then add again
            context.doctor_major.RemoveRange(context.doctor_major.Where(dm => dm.doctor_username == username));
            context.SaveChanges();

            // Add the doctor_major records for the chosenBreed_IDs
            foreach (var item in chosenBreed_ID)
            {
                Trace.WriteLine("breed_id: " + item);
                context = new TiemChungThuCungDbContext();
                context.doctor_major.Add(new doctor_major { doctor_username = username, breed_id = item });
                context.SaveChanges();
            }

            doctor doctor = context.doctors.Where(a => a.username == username)?.FirstOrDefault();
            if (doctor != null)
            {
                doctor.education = education;
                doctor.experience = experience;
            }
            context.SaveChanges();
        }

        public string getExperiencebyUsername(string username)
        {
            doctor doctor = context.doctors.FirstOrDefault(a => a.username == username);
            string experience;
            if (doctor != null)
            {
                experience = doctor.experience;
            }
            else
            {
                experience = "No data found !";
            }
            return experience;
        }

        public string getEducationbyUsername(string username)
        {
            doctor doctor = context.doctors.FirstOrDefault(a => a.username == username);
            string education;
            if (doctor != null)
            {
                education = doctor.education;
            }
            else
            {
                education = "No data found !";
            }
            return education;
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

        public doctor getDoctorbyUsername(string username)
        {
            doctor doc = context.doctors.FirstOrDefault(p => p.username == username);
            if (doc == null)
            {
                string txt = "Không có dữ liệu";
                doc = new doctor();
                doc.experience = txt;
                doc.education = txt;
            }
            return doc;
        }

        public List<string> getListBreed_ID_ProfessionbyUsername(string username)
        {
            List<string> breedIds = context.doctor_major
                .Where(dm => dm.doctor_username == username)
                ?.Select(dm => dm.breed_id)
                ?.ToList() ?? new List<string>();

            return breedIds;
        }
    }
}
