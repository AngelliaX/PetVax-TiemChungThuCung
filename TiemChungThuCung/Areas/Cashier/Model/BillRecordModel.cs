using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiemChungThuCung.Areas.Cashier.Model
{
    public class BillRecordModel
    {
        [Key]
        [StringLength(10, ErrorMessage = "Không được vượt quá 10 kí tự")]
        [Required(ErrorMessage = "Vui lòng không bỏ trống")]
        public string bill_id { get; set; }


        [StringLength(10,ErrorMessage = "Không được vượt quá 10 kí tự")]
        [Required(ErrorMessage = "Vui lòng không bỏ trống")]
        public string vaccine_code { get; set; }


        [StringLength(50, ErrorMessage = "Không được vượt quá 10 kí tự")]
        [Required(ErrorMessage = "Vui lòng không bỏ trống")]
        public string client_username { get; set; } 

     
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public int? dose_unit { get; set; }


        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(1, 999999, ErrorMessage = "Số lượng không hợp lệ hoặc quá lớn")]
        public int amount { get; set; }



    }
}