using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityFramework;
namespace TiemChungThuCung.Areas.Doctor.Models
{
    public class DoctorUpcommingModel
    {
        public DoctorUpcommingModel()
        {
            pets = new List<pet>();
            accs = new List<account>();
            breednames = new List<string>();

            All_pets = new List<pet>();
            All_accs = new List<account>();
            All_breednames = new List<string>();
        }

        //Display of specialist appointment
        public List<appointment> apps { get; set; }
        public List<pet> pets{ get; set; }
        public List<string> breednames { get; set; }
        public List<account> accs { get; set; }
        //========================================

        //Display of ALL appointment
        public List<appointment> All_apps { get; set; }
        public List<pet> All_pets { get; set; }
        public List<string> All_breednames { get; set; }
        public List<account> All_accs { get; set; }
        //========================================

        //HttpPost
        public string chosen_appointmentId { get; set; }
        //========================================
    }
}