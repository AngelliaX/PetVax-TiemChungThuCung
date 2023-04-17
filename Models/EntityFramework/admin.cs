namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        [Key]
        [StringLength(50)]
        public string username { get; set; }

        public int? salary { get; set; }

        public virtual account account { get; set; }
    }
}
