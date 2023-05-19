using Models.DataAccessLayer.BillDAL;
using Models.DataAccessLayer.VaccineDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiemChungThuCung.Areas.Cashier.Helper;
using TiemChungThuCung.Areas.Cashier.Model;

namespace TiemChungThuCung.Areas.Cashier.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Cashier/Statistics
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Revenue()
        {
            return View();
        }

        //Reven
        public ActionResult RevenueTest(int? Year)
        {
            if(Year.HasValue)
            {
                List<StatisticsModel> models = new List<StatisticsModel>();

                //Add Data 2023

                for (int m = 1; m <= 12; m++)
                {
                    models.Add(StatsHelper.Instance.GetStatYearDataByMonth(m, Year.Value));
                }



                //List<bill> models = new BillDAL().GetAllBillList();
                return View(models);
            }
            else
            {
                List<StatisticsModel> models = new List<StatisticsModel>();

                //Add Data 2023

                for (int m = 1; m <= 12; m++)
                {
                    models.Add(StatsHelper.Instance.GetStatYearDataByMonth(m, 2023));
                }



                //List<bill> models = new BillDAL().GetAllBillList();
                return View(models);
            }
           
        }


    }
}