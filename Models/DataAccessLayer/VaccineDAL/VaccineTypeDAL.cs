using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public int GetAmountOfVaccineType(string VaccineCode)
        {
            //int count = 0;
            //foreach(var Lot in db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode).ToList())
            //{
            //    count += Lot.remain_amount;   
            //}
            //return count;
            if (GetAppropriateVaccineLotByVaccineCode(VaccineCode) == null) return 0;
            else return GetAppropriateVaccineLotByVaccineCode(VaccineCode).remain_amount;
        }
        public vaccine_lot GetAppropriateVaccineLotByVaccineCode(string VaccineCode)
        {
            //vaccine_lot Lot = db.vaccine_lot.OrderBy(m => m.expiration_date).FirstOrDefault();
            vaccine_lot Lot = db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode).OrderBy(m => m.expiration_date).FirstOrDefault();
            return Lot;
        }
        public bool CheckIfVaccineCodeIsExist(string VaccineCode)
        {
            return db.vaccine_type.Count(m => m.vaccine_code == VaccineCode) > 0 ? true : false;
        }
        public int GetPriceByVaccineCode(string VaccineCode)
        {
            if (CheckIfVaccineCodeIsExist(VaccineCode))
            {
                return GetAppropriateVaccineLotByVaccineCode(VaccineCode).sale_price;
            }
            else return 0;
        }
    }
}
