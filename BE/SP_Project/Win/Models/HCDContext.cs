using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Win.Models
{
    public partial class HCDContext : DbContext
    {
        public HCDContext()
        {
        }

        public HCDContext(DbContextOptions<HCDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuPhong> ChuPhongs { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Qlnguoio> Qlnguoios { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ToaNha> ToaNhas { get; set; }
        public virtual DbSet<TtchuNha> TtchuNhas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =21AK22-COM; database = HCD;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChuPhong>(entity =>
            {
                entity.ToTable("ChuPhong");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idchu).HasColumnName("IDChu");

                entity.Property(e => e.Idphong).HasColumnName("IDPhong");

                entity.HasOne(d => d.IdchuNavigation)
                    .WithMany(p => p.ChuPhongs)
                    .HasForeignKey(d => d.Idchu)
                    .HasConstraintName("FK_ChuPhong_TTChuNha");

                entity.HasOne(d => d.IdphongNavigation)
                    .WithMany(p => p.ChuPhongs)
                    .HasForeignKey(d => d.Idphong)
                    .HasConstraintName("FK_ChuPhong_ToaNha");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Idnew);

                entity.Property(e => e.Idnew).HasColumnName("IDNew");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Tieude).HasMaxLength(100);
            });

            modelBuilder.Entity<Qlnguoio>(entity =>
            {
                entity.ToTable("QLNguoio");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idphong).HasColumnName("IDPhong");

                entity.Property(e => e.QuanheCh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QuanheCH");

                entity.HasOne(d => d.IdphongNavigation)
                    .WithMany(p => p.Qlnguoios)
                    .HasForeignKey(d => d.Idphong)
                    .HasConstraintName("FK_QLNguoio_ToaNha");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToaNha>(entity =>
            {
                entity.ToTable("ToaNha");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TtchuNha>(entity =>
            {
                entity.HasKey(e => e.Idcn);

                entity.ToTable("TTChuNha");

                entity.Property(e => e.Idcn).HasColumnName("IDcn");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idtk).HasColumnName("IDtk");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtkNavigation)
                    .WithMany(p => p.TtchuNhas)
                    .HasForeignKey(d => d.Idtk)
                    .HasConstraintName("FK_TTChuNha_TaiKhoan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
