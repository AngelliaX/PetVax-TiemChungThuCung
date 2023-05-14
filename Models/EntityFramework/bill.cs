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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            bill_vaccine = new HashSet<bill_vaccine>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_vaccine> bill_vaccine { get; set; }
    }
}
