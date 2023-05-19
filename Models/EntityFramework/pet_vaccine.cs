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
        public int record_id { get; set; }

        [Required]
        [StringLength(10)]
        public string pet_id { get; set; }

        [StringLength(10)]
        public string vaccine_code { get; set; }

        public bool? state { get; set; }

        public int? dose_order { get; set; }

        [Column(TypeName = "date")]
        public DateTime? vaccine_date { get; set; }

        public virtual pet pet { get; set; }

        public virtual vaccine_type vaccine_type { get; set; }
    }
}
