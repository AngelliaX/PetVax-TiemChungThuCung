using Models.DataAccessLayer.BillDAL;
using Models.DataAccessLayer.VaccineDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Cashier.Model
{
    public class StatisticsModel
    {
        public int income { get; set; } 
        public int outcome { get; set; }
        public int year { get; set; }
        public int month { get; set; }  
        public int day { get; set; }

        public StatisticsModel()
        {
            income = 0;
            outcome = 0;
        }
        
        
        
    }
}