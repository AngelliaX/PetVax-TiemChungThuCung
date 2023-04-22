using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer.BillDAL
{
    public class BillDAL
    {
        TiemChungThuCungDbContext db = null;
        public BillDAL() 
        {
            db = new TiemChungThuCungDbContext();
        }
        public List<bill> GetAllBillList()
        {
            var billList = db.bills.Select(m => m);
            return billList.ToList();
        }
        public void AddBill(bill billToAdd)
        {
            db.bills.Add(billToAdd);
            db.SaveChanges();
        }
        public void UpdateBill(bill billToUpdate, string BillId)
        {
            bill tmp = db.bills.Where(m => m.bill_id == BillId).FirstOrDefault();
            if (tmp != null)
            {
                tmp.bill_id = billToUpdate.bill_id;
                tmp.client_username = billToUpdate.client_username;
                tmp.init_date = billToUpdate.init_date;
                tmp.total_cost = billToUpdate.total_cost;
                tmp.description = billToUpdate.description;
                db.SaveChanges();
            }
        }
        public void DeleteBill(string BillId)
        {
            db.bills.Remove(db.bills.Where(m => m.bill_id == BillId).FirstOrDefault());
            db.SaveChanges();
        }
        public bill GettBillByBillId(string BillId)
        {
            bill tmp = db.bills.Where(m => m.bill_id == BillId).FirstOrDefault();
            return tmp;
        }
            
    }
}
