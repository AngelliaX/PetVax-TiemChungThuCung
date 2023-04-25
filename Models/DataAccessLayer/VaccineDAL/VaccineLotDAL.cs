using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer.VaccineDAL
{
    public class VaccineLotDAL
    {
        TiemChungThuCungDbContext db = null;
        public VaccineLotDAL()
        {
            db = new TiemChungThuCungDbContext();
        }
        public List<vaccine_lot> GetAllVaccineLot()
        {
            var allVaccineLot = db.vaccine_lot.Select(x => x).ToList();
            return allVaccineLot;
        }
        public void AddVaccineLot(vaccine_lot lot)
        {
            db.vaccine_lot.Add(lot);
            db.SaveChanges();
        }
        public void EditVaccineLot(vaccine_lot Lot, string LotNumber)
        {
            vaccine_lot LotToEdit = db.vaccine_lot.Where(x => x.lot_number == LotNumber).FirstOrDefault();
            if (LotToEdit != null) 
            {
                LotToEdit.vaccine_code = Lot.vaccine_code;
                LotToEdit.production_date = Lot.production_date;
                LotToEdit.expiration_date = Lot.expiration_date;
                LotToEdit.rival_date = Lot.rival_date;
                LotToEdit.total_amount = Lot.total_amount;
                LotToEdit.remain_amount = Lot.remain_amount;
                LotToEdit.dose_unit = Lot.dose_unit;
                LotToEdit.import_price = Lot.import_price;
                LotToEdit.sale_price = Lot.sale_price;
                LotToEdit.tax = Lot.tax;
                LotToEdit.publisher = Lot.publisher;
                LotToEdit.note = Lot.note;
                db.SaveChanges();
            }
        }
        public void DeleteVaccineLot(string LotNumber)
        {
            vaccine_lot LotToDel = db.vaccine_lot.Where(x => x.lot_number == LotNumber).FirstOrDefault();
            if (LotToDel != null) 
            {
                db.vaccine_lot.Remove(LotToDel);
                db.SaveChanges();
            }
        }
        public vaccine_lot GetVaccineLotByLotNumber(string LotNumber)
        {
            vaccine_lot lot = db.vaccine_lot.Where(x => x.lot_number == LotNumber).FirstOrDefault();
            return lot;
        }
        public List<vaccine_lot> GetListVaccineByVaccineCode(string VaccineCode)
        {
            var list = db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode).ToList();
            return list;
        }
      
    }
}
