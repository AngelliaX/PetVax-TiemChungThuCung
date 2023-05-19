using Models.DataAccessLayer.BillDAL;
using Models.DataAccessLayer.VaccineDAL;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiemChungThuCung.Areas.Cashier.Model;

namespace TiemChungThuCung.Areas.Cashier.Helper
{
    public class StatsHelper
    {
        private static StatsHelper _Instance;

        public static StatsHelper Instance
        {
            get
            {
                if(_Instance == null)
                { 
                    _Instance = new StatsHelper();
                }
                return _Instance;
            }
            private set { }
        }
        public StatisticsModel GetStatYearDataByMonth(int month, int year)
        {
            StatisticsModel stat = new StatisticsModel();
            BillDAL inc = new BillDAL();
            VaccineLotDAL outc = new VaccineLotDAL();

            stat.income = inc.GetRevenueByMonth(month, year);
            stat.outcome = outc.GetLostByMonth(month, year);
            stat.year = year;
            stat.month = month;
            stat.day = 1;

            return stat;
        }
        public int GetTotalIncomeByYear(int year)
        {
            int total = 0;
            for(int m = 1; m <= 12;m++)
            {
                total += GetStatYearDataByMonth(m, year).income;
            }
            return total;
        }
        public int GetTotalOutcomeByYear(int year)
        {
            int total = 0;
            for (int m = 1; m <= 12; m++)
            {
                total += GetStatYearDataByMonth(m, year).outcome;
            }
            return total;
        }
        public int GetIncomeByMonthRange(int start_month, int end_month, int year)
        {
            if(start_month >= end_month)
            {
                return 0;
            }
            else
            {
                int total = 0;
                for (int m = start_month; m <= end_month; m++)
                {
                    total += GetStatYearDataByMonth(m, year).income;
                }
                return total;
            }
        }
        public int GetProfitByYear(int year)
        {
            int profit = GetTotalIncomeByYear(year) - GetTotalOutcomeByYear(year);
            return profit;
        }
        public float GetGrowthByYear(int year)
        {
            float PostValue = (float)GetTotalIncomeByYear(year);
            float PreValue = (float)GetIncomeByMonthRange(1, DateTime.Now.Month, year - 1);
            float growth = (PostValue - PreValue) * 100 / PreValue;
            return growth;
            
        }
        public double RevenueCompareToLastYear(int year)
        {

            double PostValue = (float)GetTotalIncomeByYear(year);
            double PreValue = (float)GetTotalIncomeByYear(year - 1);
            if(PreValue == 0)  return 100; 
            else
            {
                double Proportion = PostValue * 100 / PreValue;
                return Math.Round(Proportion, 2);
            }
            
        }
        public int GetIncomeByDay(int day, int month, int year)
        {
            return new BillDAL().GetInComeByDay(day,month,year);
        }

        public int GetBillAmountByWeek(int day, int month, int year)
        {
            int amount = 0;
            for(int i = day; i > day - 7; i--)
            {
                amount += new BillDAL().GetBillAmountByDay(i,month,year);
            }
            return amount;
        }
    }
}