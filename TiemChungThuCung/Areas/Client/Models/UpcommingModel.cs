using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EntityFramework;

namespace TiemChungThuCung.Areas.Client.Models
{
    public class UpcommingModel
    {

        //On display
        public List<appointment> apps { get; set; }
        public List<string> petname { get; set; }
        public List<account> accs { get; set; }
        public List<doctor> docs { get; set; }

        public UpcommingModel()
        {
            petname = new List<string>();
            accs = new List<account>();
            docs = new List<doctor>();
        }
        //========


    }
}