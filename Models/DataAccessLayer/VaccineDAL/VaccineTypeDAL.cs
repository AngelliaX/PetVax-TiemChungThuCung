using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer.VaccineDAL
{
    public class VaccineTypeDAL
    {
        TiemChungThuCungDbContext db = null;
        public VaccineTypeDAL()
        {
            db = new TiemChungThuCungDbContext();
        }
        public  List<vaccine_type> GetAllVaccineType()
        {
            var allVaccineType = db.vaccine_type.Select(x => x);
            return allVaccineType.ToList();
        }   
        public void AddVaccineType(vaccine_type vctype)
        {
            db.vaccine_type.Add(vctype);
            db.SaveChanges();
        }
        public void EditVaccineType(vaccine_type VaccineType, string VaccineCode) 
        {
            vaccine_type VaccineTypeToEdit = db.vaccine_type.Where(x => x.vaccine_code== VaccineCode).FirstOrDefault();
            if(VaccineTypeToEdit != null) 
            {
                VaccineTypeToEdit.vaccine_name = VaccineType.vaccine_name;
                VaccineTypeToEdit.country_of_origin = VaccineType.country_of_origin;
                VaccineTypeToEdit.note = VaccineType.note;
                db.SaveChanges();
            }
        }
        public void DeleteVaccineType(string VaccineCode)
        {
            vaccine_type TypeToDel = db.vaccine_type.Where(x => x.vaccine_code == VaccineCode).FirstOrDefault();    
            if(TypeToDel != null) 
            {
                db.vaccine_type.Remove(TypeToDel);
                db.SaveChanges();
            }
        }

    }
}
