using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EntityFramework
{
    public partial class TiemChungThuCungDbContext : DbContext
    {
        public TiemChungThuCungDbContext()
            : base("name=TiemChungThuCungDbContext")
        {
        }

        public virtual DbSet<account> accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.birthday)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.account_init_day)
                .IsUnicode(false);
        }
    }
}
