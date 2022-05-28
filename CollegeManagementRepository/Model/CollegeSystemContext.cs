using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CollegeManagementRepository.Model
{
    public partial class CollegeSystemContext : DbContext
    {
        public CollegeSystemContext()
        {
        }

        public CollegeSystemContext(DbContextOptions<CollegeSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CampusSelect> CampusSelects { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CollegeSystem;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CampusSelect>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CampusSelect");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RollNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RollNo)
                    .HasConstraintName("FK__CampusSel__RollN__24927208");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.RollNo)
                    .HasName("PK__Student__7886D5A07BC68E29");

                entity.ToTable("Student");

                entity.Property(e => e.RollNo).ValueGeneratedNever();

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Marks).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
