namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pet_disease
    {
        [Key]
        [StringLength(10)]
        public string pet_id { get; set; }

        [StringLength(10)]
        public string disease_code { get; set; }

        public virtual disease disease { get; set; }

        public virtual pet pet { get; set; }
    }
}
