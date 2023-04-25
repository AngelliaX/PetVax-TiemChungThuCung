using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Doctor.Models
{
    public class ProfessionModel
    {
        public List<string> breed_id { set; get; }
        public List<string> breed_name { set; get; }
        
        public List<string> chosenBreed_id { set; get; }
        public string experience { set; get; }
        public string education { set; get; }

    }
}