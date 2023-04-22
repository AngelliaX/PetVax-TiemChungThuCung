namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vaccine_compatible
    {
        [Key]
        [StringLength(10)]
        public string disease_code { get; set; }

        [StringLength(10)]
        public string vaccine_code { get; set; }

        public virtual disease disease { get; set; }

        public virtual vaccine_type vaccine_type { get; set; }
    }
}
