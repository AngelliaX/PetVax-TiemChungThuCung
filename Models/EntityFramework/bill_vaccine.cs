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
        [Column(Order = 0)]
        [StringLength(10)]
        public string bill_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string vaccine_code { get; set; }

        public int? amount { get; set; }

        public int? cost { get; set; }

        public virtual bill bill { get; set; }

        public virtual vaccine_type vaccine_type { get; set; }
    }
}
