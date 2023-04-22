namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class doctor_major
    {
        [Key]
        [StringLength(50)]
        public string doctor_username { get; set; }

        [StringLength(10)]
        public string breed_id { get; set; }

        public virtual breed breed { get; set; }

        public virtual doctor doctor { get; set; }
    }
}
