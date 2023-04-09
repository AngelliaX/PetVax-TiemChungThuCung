namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [Key]
        public int account_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string username { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string password { get; set; }

        public int? account_type { get; set; }

        [Column(TypeName = "text")]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string phone { get; set; }

        [Column(TypeName = "text")]
        public string email { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }

        [Column(TypeName = "text")]
        public string birthday { get; set; }

        [Column(TypeName = "text")]
        public string account_init_day { get; set; }

        public bool? isTerminated { get; set; }
    }
}
