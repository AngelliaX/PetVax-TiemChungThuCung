namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("appointment")]
    public partial class appointment
    {
        [Key]
        [StringLength(10)]
        public string appointment_id { get; set; }

        [StringLength(10)]
        public string pet_id { get; set; }

        [StringLength(50)]
        public string doctor_username { get; set; }

        public bool? state { get; set; }

        [Column(TypeName = "date")]
        public DateTime? init_day { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(200)]
        public string note { get; set; }

        public virtual doctor doctor { get; set; }

        public virtual pet pet { get; set; }
    }
}
