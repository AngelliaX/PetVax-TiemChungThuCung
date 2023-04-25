using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Client.Models
{
    public class CreateAppointmentModel
    {
        public account account { get; set; }
        public List<pet> listPet { get; set; }
        [Required(ErrorMessage = "Hãy chọn 1 con")]
        public string chosenPetID { get; set; }
        [Required(ErrorMessage = "Hãy chọn ngày giờ")]
        public DateTime date { get; set; }
        public string note { get; set; }
    }
}