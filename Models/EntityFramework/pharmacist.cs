namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pharmacist")]
    public partial class pharmacist
    {
        [Key]
        [StringLength(50)]
        public string username { get; set; }

        public int? salary { get; set; }

        public virtual account account { get; set; }
    }
}
