using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            db.SaveChanges();
        }
    }
}
