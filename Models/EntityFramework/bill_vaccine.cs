namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill_vaccine
    {

        [Key]
        [StringLength(10)]
        public string bill_id { get; set; }

        [StringLength(10, ErrorMessage = "Không được vượt quá 10 kí tự")]
        public string vaccine_lot_number { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống")]
        public int amount { get; set; }

        public int cost { get; set; }


        public virtual bill bill { get; set; }


        public virtual vaccine_lot vaccine_lot { get; set; }
    }
}
