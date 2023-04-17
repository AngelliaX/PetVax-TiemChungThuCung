namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pet")]
    public partial class pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pet()
        {
            appointments = new HashSet<appointment>();
            pet_vaccine = new HashSet<pet_vaccine>();
        }

        [Key]
        [StringLength(10)]
        public string pet_id { get; set; }

        [StringLength(10)]
        public string breed_id { get; set; }

        [StringLength(50)]
        public string client_username { get; set; }

        [StringLength(50)]
        public string pet_name { get; set; }

        public int? age { get; set; }

        public double? weight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointments { get; set; }

        public virtual breed breed { get; set; }

        public virtual client client { get; set; }

        public virtual pet_disease pet_disease { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pet_vaccine> pet_vaccine { get; set; }
    }
}
