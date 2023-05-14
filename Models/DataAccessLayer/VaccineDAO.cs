using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;
namespace Models.DataAccessLayer
{
    public class VaccineDAO
    {
        private TiemChungThuCungDbContext context = null;
        public VaccineDAO()
        {
            context = new TiemChungThuCungDbContext();
        }

        public List<string> getList_AllVaccineId()
        {
            List<string> list = context.vaccine_type.Select(v => v.vaccine_code).ToList();
            return list;
        }
        public List<string> getList_AllVaccineName()
        {
            List<string> list = context.vaccine_type.Select(v => v.vaccine_name).ToList();
            return list;
        }
        public string getVaccineNamefromVaccineId(string vaccineId)
        {
            vaccine_type vac_type = context.vaccine_type.FirstOrDefault(v => v.vaccine_code == vaccineId) ?? new vaccine_type();

            if (vac_type != null)
            {
                return vac_type.vaccine_name;
            }
            else
            {
                return "Có lỗi VaccineDAO.cs";
            }
        }
        public void addVaccineToPet(string petId, string vaccine_code, int doseNumber, DateTime vaccineDateToJab)
        {
            pet_vaccine pet_vac = new pet_vaccine();
            pet_vac.pet_id = petId;
            pet_vac.vaccine_code = vaccine_code;
            pet_vac.state = false;
            pet_vac.dose_order = doseNumber;
            pet_vac.vaccine_date = vaccineDateToJab;
            context.pet_vaccine.Add(pet_vac);
            context.SaveChanges();
        }

        public List<pet_vaccine> getList_AllPet_VaccineFromPetId(string pet_id)
        {
            var list = context.pet_vaccine.Where(a => a.pet_id == pet_id).ToList();
            return list;
        }

        public List<string> getList_VaccineNameFromListPet_vaccine(List<pet_vaccine> listPet_vaccine)
        {
            List<string> vacName = new List<string>();
            foreach (var pet_vacc in listPet_vaccine)
            {
                vacName.Add(getVaccineNamefromVaccineId(pet_vacc.vaccine_code));
            }
            return vacName;
        }

        public void removePet_Vaccine(int record_id)
        {
            var item = context.pet_vaccine.FirstOrDefault(v => v.record_id == record_id);
            if (item != null)
            {
                context.pet_vaccine.Remove(item);
                context.SaveChanges();
            }
        }

        public void syncRecord(pet_vaccine record)
        {
            var item = context.pet_vaccine.FirstOrDefault(v => v.record_id == record.record_id);
            if (item == null) { return; }
            if (item.state != record.state)
            {
                item.state = record.state;
                context.SaveChanges();
            }
        }

        private string getDiseaseNamefromCode(string code)
        {
            var item = context.diseases.FirstOrDefault(v => v.disease_code == code);
            return item.disease_name;
        }
        public string getDiseaseNamefromVaccineCode(string vaccine_code)
        {
            var item = context.vaccine_compatible.FirstOrDefault(v => v.vaccine_code == vaccine_code);
            if (item == null)
            {
                return "Retrieve name error";
            }
            return getDiseaseNamefromCode(item.disease_code);
            
            
        }
    }
}
