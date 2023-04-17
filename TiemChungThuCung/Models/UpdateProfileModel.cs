using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Models
{
    public class UpdateProfileModel
    {
        public string name { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string address { set; get; }
        public DateTime? birthday { set; get; }
        public string username { set; get; }

        public string oldpassword { set; get; }
        public string newpassword { set; get; }
    }
}