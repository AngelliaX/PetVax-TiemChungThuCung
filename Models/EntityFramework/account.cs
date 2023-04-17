namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [Key]
        [StringLength(50)]
        [Required]
        public string username { get; set; }

        [StringLength(50)]
        [Required]
        public string password { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [Column(TypeName = "date")]
        public DateTime? account_init_day { get; set; }

        public bool? isTerminated { get; set; }

        public int? account_type { get; set; }

        public virtual admin admin { get; set; }

        public virtual cashier cashier { get; set; }

        public virtual client client { get; set; }

        public virtual doctor doctor { get; set; }

        public virtual pharmacist pharmacist { get; set; }
    }
}
