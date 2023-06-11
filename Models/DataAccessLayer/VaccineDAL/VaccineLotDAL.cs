using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
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
        public List<vaccine_lot> GetAvailableLots()
        {
            return db.vaccine_lot.Where(m => m.isDeleted == false).ToList();
        }
        public List<vaccine_lot> SearchByFilter(string SearchText = "", string PropName = "None", bool order = true){

            List<vaccine_lot> list = new List<vaccine_lot>();
            list = GetAvailableLots();
            list = list.Where(m => m.vaccine_type.vaccine_name.ToLower().Contains(SearchText) || m.lot_number.ToLower().Contains(SearchText)).ToList();
            if(PropName == "None")
            {
                return list;
            }
            else
            {
                switch (PropName)
                {
                    case "vaccine_name":
                        if (order == true) return list.OrderBy(m => m.vaccine_type.vaccine_name).ToList();
                        else return list.OrderByDescending(m => m.vaccine_type.vaccine_name).ToList();
                        break;
                    case "total_cost":
                        if(order == true) return list.OrderBy(m => m.total_amount * m.import_price).ToList();
                        else return list.OrderByDescending(m => m.total_amount * m.import_price).ToList();
                        break;
                    default:
                        PropertyInfo prop = typeof(vaccine_lot).GetProperty(PropName);
                        if (order == true) return list.OrderBy(m => prop.GetValue(m)).ToList();
                        else return list.OrderByDescending(m => prop.GetValue(m)).ToList();      
                        break;
                }
            }
        }
        public void AddVaccineLot(vaccine_lot lot)
        {
            lot.isDeleted = false;
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
                LotToDel.isDeleted = true;
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
        public int GetTotalCostByVaccineLot(string VaccineLot)
        {
            vaccine_lot tmp = db.vaccine_lot.Where(m => m.lot_number == VaccineLot).FirstOrDefault();
            if (tmp != null)
            {
                int cost = tmp.import_price * tmp.total_amount;
                return cost;
            }
            else return 0;
        }
        public int GetCostByDate(DateTime date)
        {
            int cost= 0;
            foreach (vaccine_lot i in db.vaccine_lot.Where(m => m.rival_date == date).ToList())
            {
                cost += i.import_price * i.total_amount;
            }
            return cost;
        }
        public int GetLostByMonth(int month, int year)
        {
            int cost = 0;
            foreach (vaccine_lot i in db.vaccine_lot.Where(m => m.rival_date.Month == month && m.rival_date.Year == year).ToList())
            {
                cost += i.import_price * i.total_amount;
            }
            return cost;
        }
        public vaccine_lot GetAppropriateVaccineLotByVaccineCode(string VaccineCode)
        { 
            //vaccine_lot Lot = db.vaccine_lot.OrderBy(m => m.expiration_date).FirstOrDefault();
            vaccine_lot Lot = db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode && m.remain_amount > 0 && m.expiration_date > DateTime.Now && m.isDeleted == false).OrderBy(m => m.expiration_date).FirstOrDefault();
            return Lot;
        }
        public void ReduceVaccineAmount(string VaccineCode, int amountToReduce)
        {
            foreach(var lot in db.vaccine_lot.Where(m => m.vaccine_code == VaccineCode && m.expiration_date > DateTime.Now && m.isDeleted == false).OrderBy(m => m.expiration_date))
            {
                if (lot.remain_amount < amountToReduce)
                {
                    amountToReduce -= lot.remain_amount;
                    lot.remain_amount = 0;
                }
                else
                {
                    lot.remain_amount -= amountToReduce;
                    break;
                }
            }
            db.SaveChanges();
        }
    }
}
