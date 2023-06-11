using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
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
        public List<vaccine_type> GetAllVaccineType()
        {
            var allVaccineType = db.vaccine_type.Select(x => x);
            return allVaccineType.ToList();
        }   
        public List<vaccine_type> SearchByFilter(string SearchText = "")
        {
            List<vaccine_type> list = new List<vaccine_type>();
            list = db.vaccine_type.Where(m => m.vaccine_code.Contains(SearchText) || m.vaccine_name.Contains(SearchText) || m.country_of_origin.Contains(SearchText)).ToList();
            return list;

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
            int amount = 0;

            List<vaccine_lot> lots = db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode && m.expiration_date > DateTime.Now && m.isDeleted == false).ToList();
            foreach(vaccine_lot lot in lots)
            {
                amount += lot.remain_amount;
            }
            return amount;
            //if (GetAppropriateVaccineLotByVaccineCode(VaccineCode) == null) return 0;
            //else return GetAppropriateVaccineLotByVaccineCode(VaccineCode).remain_amount;
        }
        public vaccine_lot GetAppropriateVaccineLotByVaccineCode(string VaccineCode)
        {
            //vaccine_lot Lot = db.vaccine_lot.OrderBy(m => m.expiration_date).FirstOrDefault();
            vaccine_lot Lot = db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode && m.remain_amount > 0 && m.expiration_date > DateTime.Now && m.isDeleted == false).OrderBy(m => m.expiration_date).FirstOrDefault();
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
                vaccine_lot lot = GetAppropriateVaccineLotByVaccineCode(VaccineCode);
                if (lot != null)
                    return lot.sale_price;
                else
                    return 0;
            }
            else return 0;
        }
        public string GetVaccineCodeByLotNumber(string LotNumber)
        {
            return db.vaccine_lot.Find(LotNumber).vaccine_code;
        }
    }
}
