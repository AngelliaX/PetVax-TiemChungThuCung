namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("doctor")]
    public partial class doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doctor()
        {
            appointments = new HashSet<appointment>();
        }

        [Key]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(10)]
        public string breed_id { get; set; }

        public int? salary { get; set; }

        public string experience { get; set; }

        public string education { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointments { get; set; }

        public virtual doctor_major doctor_major { get; set; }
    }
}
