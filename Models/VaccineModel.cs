using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VaccineModel
    {
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(10, ErrorMessage = "Số lô không được vượt quá 10 kí tự")]
        public string lot_number { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(10, ErrorMessage = "Mã vaccine không vượt quá 10 kí tự")]
        public string vaccine_code { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(50, ErrorMessage = "Tên vaccine không được vượt quá 50 kí tự")]
        public string vaccine_name { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime production_date { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime expiration_date { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime rival_date { get; set; }

        //====================================================================
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 kí tự")]
        public string country_of_origin { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(1,99999, ErrorMessage = "Số lượng nhập không hợp lệ hoặc quá lớn")]
        public int? total_amount { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(1, 99999, ErrorMessage = "Số lượng nhập không hợp lệ hoặc quá lớn")]
        public int? remain_amount { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public int? dose_unit { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(1, 999999, ErrorMessage = "Giá nhập không hợp lệ hoặc quá lớn")]
        public int? import_price { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(1, 999999, ErrorMessage = "Giá nhập không hợp lệ hoặc quá lớn")]
        public int? sale_price { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(0, 999999, ErrorMessage = "Giá trị nhập vào không được âm")]
        public int? tax { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(200, ErrorMessage = "Không được vượt quá 200 kí tự")]
        public string publisher { get; set; }

        //====================================================================
        [StringLength(400, ErrorMessage = "Không được vượt quá 400 kí tự")]
        public string lot_note { get; set; }

        //====================================================================
        //[StringLength(400, ErrorMessage = "Không được vượt quá 400 kí tự")]
        //public string vaccine_type_note { get; set; }
    }
}
