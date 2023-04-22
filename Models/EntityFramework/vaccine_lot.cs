namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vaccine_lot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vaccine_lot()
        {
            bill_vaccine = new HashSet<bill_vaccine>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "Số lô không được vượt quá 10 kí tự")]
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public string lot_number { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(10, ErrorMessage = "Mã vaccine không vượt quá 10 kí tự")]
        public string vaccine_code { get; set; }

        //====================================================================
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime production_date { get; set; }

        //====================================================================
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime expiration_date { get; set; }

        //====================================================================
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime rival_date { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [Range(1, 99999, ErrorMessage = "Số lượng nhập không hợp lệ hoặc quá lớn")]
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
        [Range(0, 999999, ErrorMessage = "Giá trị nhập vào không hợp lệ hoặc quá lớn")]
        public int? tax { get; set; }

        //====================================================================
        [Required(ErrorMessage = "Vui lòng không để trống")]
        [StringLength(200, ErrorMessage = "Không được vượt quá 200 kí tự")]
        public string publisher { get; set; }

        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_vaccine> bill_vaccine { get; set; }

        public virtual vaccine_type vaccine_type { get; set; }
    }
}
