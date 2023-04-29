namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [Key]
        [StringLength(10, ErrorMessage = "Không được vượt qúa 10 kí tự")]
        [Required(ErrorMessage ="Vui lòng không để trống")]
        public string bill_id { get; set; }

        [StringLength(50, ErrorMessage = "Không được vượt quá 50 kí tự")]
        public string client_username { get; set; }

        [Required(ErrorMessage = "Vui lòng không để trống")]
        public DateTime init_date { get; set; }

        public int total_cost { get; set; }

        public string description { get; set; }


        public virtual client client { get; set; }

        public virtual bill_vaccine bill_vaccine { get; set; }
    }
}
