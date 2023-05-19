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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bill_vaccine_key { get; set; }

        [Required]
        [StringLength(10)]
        public string bill_id { get; set; }
         

        [StringLength(10)]
        public string vaccine_lot_number { get; set; }

        public int? amount { get; set; }

        public int? cost { get; set; }

        public virtual bill bill { get; set; }

        public virtual vaccine_lot vaccine_lot { get; set; }
    }
}
