using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
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
        public List<bill> SearchByFiter(string SearchText = "", string PropName = "", bool Order = true)
        {
            List<bill> list = new List<bill>();
            list = db.bills.Where(m => m.bill_id.Contains(SearchText) || m.client.account.name.Contains(SearchText)).ToList();
            if(PropName == "None")
            {
                return list;
            }
            else
            {
                switch (PropName)
                {
                    case "client_name":
                        if (Order == true) return list.OrderBy(m => m.client.account.name).ToList();
                        else return list.OrderByDescending(m => m.client.account.name).ToList();
                        break;
                    default:
                        PropertyInfo prop = typeof(bill).GetProperty(PropName); 
                        if(Order == true) return list.OrderBy(m => prop.GetValue(m)).ToList();
                        else return list.OrderByDescending(m => prop.GetValue(m)).ToList();
                }
            }


     
        }
        public bool CheckIfBillIsExist(string BillId)
        {
            //Check trùng id
            if (db.bills.Count(m => m.bill_id == BillId) > 0) return true;
            else return false;
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
            new BillVaccineDAL().DeleteBillVaccine(BillId);
            db.bills.Remove(db.bills.Find(BillId));
            db.SaveChanges();
        }
        public bill GettBillByBillId(string BillId)
        {
            bill tmp = db.bills.Where(m => m.bill_id == BillId).FirstOrDefault();
            return tmp;
        }
        public int GetRevenueByDate(DateTime date)
        {
            int Reven = 0;
            foreach(bill i in db.bills.Where(m => m.init_date == date).ToList()) 
            {
                Reven += i.total_cost;
            }
            return Reven;
        }
        public int GetRevenueByMonth(int month, int year)
        {
            int Reven = 0; 
            foreach(bill i in db.bills.Where(m => m.init_date.Month == month && m.init_date.Year == year).ToList())
            {
                Reven += i.total_cost;  
            }
            return Reven;
        }
        public List<int> GetRevenueByDayRange(DateTime StartDate, DateTime EndDate)
        {
            if(StartDate >= EndDate)
            {
                List<int> list = new List<int>(); 
                list.Add(0);
                throw new Exception("Thời gian nhập không hợp lệ");
                return list;
            }
            else
            {
                List<int> reven = new List<int>();
                for(DateTime i = StartDate; i <= EndDate; i.AddDays(1))
                {
                    reven.Add(GetRevenueByDate(i));
                    
                }
                return reven;
            }
        }
        public string GetBillId()
        {
            string LastId = db.bills.ToList().OrderBy(m => m.init_date).Last().bill_id;
            string id = LastId.Substring(0);
            int tmp = int.Parse(id) + 1;
            return tmp.ToString();
        }
        public int GetInComeByDay(int day, int month, int year)
        {
            int income = 0;
            List<bill> list = new List<bill>();
            list = db.bills.Where(m => m.init_date.Day == day && m.init_date.Month == month && m.init_date.Year == year).ToList();
            foreach (var i in list)
            {
                income += i.total_cost;
            }
            return income;  
        }
        public int GetBillAmountByDay(int day, int month, int year) 
        {
            int amount = 0;
            List<bill> list = new List<bill>();
            list = db.bills.Where(m => m.init_date.Day == day && m.init_date.Month == month && m.init_date.Year == year).ToList();
            foreach (var i in list)
            {
                amount++;
            }
            return amount;
        }
            
    }
}
