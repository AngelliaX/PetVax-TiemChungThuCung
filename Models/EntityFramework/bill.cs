namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [Key]
        [StringLength(10)]
        public string bill_id { get; set; }

        [StringLength(50)]
        public string client_username { get; set; }

        [Column(TypeName = "date")]
        public DateTime? init_date { get; set; }

        public int? total_cost { get; set; }

        public string description { get; set; }

        public virtual client client { get; set; }

        public virtual bill_vaccine bill_vaccine { get; set; }
    }
}
