using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer.BillDAL
{
    public class BillVaccineDAL
    {
        TiemChungThuCungDbContext db = null;
        public BillVaccineDAL() 
        {
            db = new TiemChungThuCungDbContext();
        }

        public void AddBillVaccine(bill_vaccine BillVaccine) 
        {
            db.bill_vaccine.Add(BillVaccine);

            vaccine_lot tmp = db.vaccine_lot.Where(m => m.lot_number == BillVaccine.vaccine_lot_number).FirstOrDefault();
            tmp.remain_amount -= BillVaccine.amount;
            db.SaveChanges();
        }

        public List<bill_vaccine> GetListBillVaccineByBillID(string BillID)
        {
            List<bill_vaccine> BillVaccines = db.bill_vaccine.Where(m => m.bill_id == BillID).ToList();
            return BillVaccines;
        }

        public void DeleteBillVaccine(string billID) 
        {
            db.bill_vaccine.RemoveRange(db.bill_vaccine.Where(m => m.bill_id == billID));
        }

        //public void Update(List<bill_vaccine> BillVaccine)
        //{
        //    db.bill_vaccine.AddOrUpdate(BillVaccine);
        //}
    }
}
