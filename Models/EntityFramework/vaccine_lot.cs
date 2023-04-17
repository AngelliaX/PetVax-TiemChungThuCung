namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vaccine_lot
    {
        [Key]
        [StringLength(10)]
        public string lot_number { get; set; }

        [StringLength(10)]
        public string vaccine_code { get; set; }

        [Column(TypeName = "date")]
        public DateTime? production_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expiration_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rival_date { get; set; }

        public int? total_amount { get; set; }

        public int? remain_amount { get; set; }

        public int? dose_unit { get; set; }

        public virtual vaccine_type vaccine_type { get; set; }
    }
}
