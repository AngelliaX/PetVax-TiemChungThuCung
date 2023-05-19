namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vaccine_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vaccine_type()
        {
            pet_vaccine = new HashSet<pet_vaccine>();
            vaccine_compatible = new HashSet<vaccine_compatible>();
            vaccine_lot = new HashSet<vaccine_lot>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "Dữ liệu không được vượt quá 10 kí tự")]
        [Required(ErrorMessage = "Vui lòng không để trống dữ liệu")]
        public string vaccine_code { get; set; }

        [StringLength(50, ErrorMessage = "Dữ liệu không được vượt quá 50 kí tự")]
        [Required(ErrorMessage = "Vui lòng không để trống dữ liệu")]
        public string vaccine_name { get; set; }

        [StringLength(50, ErrorMessage = "Dữ liệu không được vượt quá 50 kí tự")]
        [Required(ErrorMessage = "Vui lòng không để trống")]
        public string country_of_origin { get; set; }

        [StringLength(400, ErrorMessage = "Dữ liệu không được vượt quá 400 kí tự")]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pet_vaccine> pet_vaccine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vaccine_compatible> vaccine_compatible { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vaccine_lot> vaccine_lot { get; set; }
    }
}
