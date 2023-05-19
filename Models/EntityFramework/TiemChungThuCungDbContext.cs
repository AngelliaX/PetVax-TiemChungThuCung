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
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<bill_vaccine> bill_vaccine { get; set; }
        public virtual DbSet<breed> breeds { get; set; }
        public virtual DbSet<cashier> cashiers { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<disease> diseases { get; set; }
        public virtual DbSet<doctor> doctors { get; set; }
        public virtual DbSet<pet> pets { get; set; }
        public virtual DbSet<pharmacist> pharmacists { get; set; }
        public virtual DbSet<vaccine_lot> vaccine_lot { get; set; }
        public virtual DbSet<vaccine_type> vaccine_type { get; set; }
        public virtual DbSet<doctor_major> doctor_major { get; set; }
        public virtual DbSet<pet_disease> pet_disease { get; set; }
        public virtual DbSet<pet_vaccine> pet_vaccine { get; set; }
        public virtual DbSet<vaccine_compatible> vaccine_compatible { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
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
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasOptional(e => e.admin)
                .WithRequired(e => e.account);

            modelBuilder.Entity<account>()
                .HasOptional(e => e.cashier)
                .WithRequired(e => e.account);

            modelBuilder.Entity<account>()
                .HasOptional(e => e.client)
                .WithRequired(e => e.account);

            modelBuilder.Entity<account>()
                .HasOptional(e => e.doctor)
                .WithRequired(e => e.account);

            modelBuilder.Entity<account>()
                .HasOptional(e => e.pharmacist)
                .WithRequired(e => e.account);

            modelBuilder.Entity<admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.appointment_id)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.pet_id)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.doctor_username)
                .IsUnicode(false);

            modelBuilder.Entity<appointment>()
                .Property(e => e.note)
                .IsFixedLength();

            modelBuilder.Entity<bill>()
                .Property(e => e.bill_id)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .Property(e => e.client_username)
                .IsUnicode(false);

            modelBuilder.Entity<bill>()
                .HasMany(e => e.bill_vaccine)
                .WithRequired(e => e.bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bill_vaccine>()
                .Property(e => e.bill_id)
                .IsUnicode(false);

            modelBuilder.Entity<bill_vaccine>()
                .Property(e => e.vaccine_lot_number)
                .IsUnicode(false);

            modelBuilder.Entity<breed>()
                .Property(e => e.breed_id)
                .IsUnicode(false);

            modelBuilder.Entity<cashier>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.bills)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.client_username);

            modelBuilder.Entity<client>()
                .HasMany(e => e.pets)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.client_username);

            modelBuilder.Entity<disease>()
                .Property(e => e.disease_code)
                .IsUnicode(false);

            modelBuilder.Entity<disease>()
                .HasOptional(e => e.vaccine_compatible)
                .WithRequired(e => e.disease);

            modelBuilder.Entity<doctor>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.breed_id)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.appointments)
                .WithOptional(e => e.doctor)
                .HasForeignKey(e => e.doctor_username);

            modelBuilder.Entity<doctor>()
                .HasOptional(e => e.doctor_major)
                .WithRequired(e => e.doctor);

            modelBuilder.Entity<pet>()
                .Property(e => e.pet_id)
                .IsUnicode(false);

            modelBuilder.Entity<pet>()
                .Property(e => e.breed_id)
                .IsUnicode(false);

            modelBuilder.Entity<pet>()
                .Property(e => e.client_username)
                .IsUnicode(false);

            modelBuilder.Entity<pet>()
                .HasOptional(e => e.pet_disease)
                .WithRequired(e => e.pet);

            modelBuilder.Entity<pet>()
                .HasOptional(e => e.pet_vaccine)
                .WithRequired(e => e.pet);

            modelBuilder.Entity<pharmacist>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<vaccine_lot>()
                .Property(e => e.lot_number)
                .IsUnicode(false);

            modelBuilder.Entity<vaccine_lot>()
                .Property(e => e.vaccine_code)
                .IsUnicode(false);

            modelBuilder.Entity<vaccine_lot>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<vaccine_lot>()
                .HasMany(e => e.bill_vaccine)
                .WithOptional(e => e.vaccine_lot)
                .HasForeignKey(e => e.vaccine_lot_number);

            modelBuilder.Entity<vaccine_type>()
                .Property(e => e.vaccine_code)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_major>()
                .Property(e => e.doctor_username)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_major>()
                .Property(e => e.breed_id)
                .IsUnicode(false);

            modelBuilder.Entity<pet_disease>()
                .Property(e => e.pet_id)
                .IsUnicode(false);

            modelBuilder.Entity<pet_disease>()
                .Property(e => e.disease_code)
                .IsUnicode(false);

            modelBuilder.Entity<pet_vaccine>()
                .Property(e => e.pet_id)
                .IsUnicode(false);

            modelBuilder.Entity<pet_vaccine>()
                .Property(e => e.vaccine_code)
                .IsUnicode(false);

            modelBuilder.Entity<vaccine_compatible>()
                .Property(e => e.disease_code)
                .IsUnicode(false);

            modelBuilder.Entity<vaccine_compatible>()
                .Property(e => e.vaccine_code)
                .IsUnicode(false);
        }
    }
}
