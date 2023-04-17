namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pet_vaccine
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string pet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string vaccinechosen_code { get; set; }

        public bool? state { get; set; }

        public int? dose_order { get; set; }

        [Column(TypeName = "date")]
        public DateTime? vaccine_date { get; set; }

        public virtual pet pet { get; set; }

        public virtual vaccine_type vaccine_type { get; set; }
    }
}
