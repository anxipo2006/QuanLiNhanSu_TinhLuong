using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using QuanLiNhanSu_TinhLuong.Models;

namespace QuanLiNhanSu_TinhLuong.Data;

public partial class QuanlynhansuContext : DbContext
{
    public QuanlynhansuContext()
    {
    }

    public QuanlynhansuContext(DbContextOptions<QuanlynhansuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bangluong> Bangluongs { get; set; }

    public virtual DbSet<Chamcong> Chamcongs { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phongban> Phongbans { get; set; }

    public virtual DbSet<Vipham> Viphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=quanlynhansu;port=3305;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));
        => optionsBuilder.UseMySql("server=localhost;database=QuanLyNhanSu_DB;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NhanVien'");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Bangluong>(entity =>
        {
            entity.HasKey(e => e.MaBl).HasName("PRIMARY");

            entity.ToTable("bangluong");

            entity.HasIndex(e => e.MaNv, "MaNV");

            entity.Property(e => e.MaBl).HasColumnName("MaBL");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.ThangNam).HasMaxLength(7);
            entity.Property(e => e.TongTienLuong)
                .HasPrecision(18)
                .HasDefaultValueSql("'0'");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Bangluongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("bangluong_ibfk_1");
        });

        modelBuilder.Entity<Chamcong>(entity =>
        {
            entity.HasKey(e => e.MaCc).HasName("PRIMARY");

            entity.ToTable("chamcong");

            entity.HasIndex(e => e.MaNv, "MaNV");

            entity.Property(e => e.MaCc).HasColumnName("MaCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.SoNgayDiLam).HasDefaultValueSql("'0'");
            entity.Property(e => e.ThangNam).HasMaxLength(7);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Chamcongs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("chamcong_ibfk_1");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PRIMARY");

            entity.ToTable("chucvu");

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.PhuCap)
                .HasPrecision(18)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.TenCv)
                .HasMaxLength(100)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PRIMARY");

            entity.ToTable("nhanvien");

            entity.HasIndex(e => e.MaCv, "MaCV");

            entity.HasIndex(e => e.MaPb, "MaPB");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
           // entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.LuongCoBan).HasPrecision(18);
            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.MaPb).HasColumnName("MaPB");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("nhanvien_ibfk_2");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaPb)
                .HasConstraintName("nhanvien_ibfk_1");
        });

        modelBuilder.Entity<Phongban>(entity =>
        {
            entity.HasKey(e => e.MaPb).HasName("PRIMARY");

            entity.ToTable("phongban");

            entity.Property(e => e.MaPb).HasColumnName("MaPB");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenPb)
                .HasMaxLength(100)
                .HasColumnName("TenPB");
        });

        modelBuilder.Entity<Vipham>(entity =>
        {
            entity.HasKey(e => e.MaVp).HasName("PRIMARY");

            entity.ToTable("vipham");

            entity.HasIndex(e => e.MaNv, "MaNV");

            entity.Property(e => e.MaVp).HasColumnName("MaVP");
            entity.Property(e => e.LyDo).HasMaxLength(255);
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.TienPhat)
                .HasPrecision(18)
                .HasDefaultValueSql("'0'");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Viphams)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("vipham_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
