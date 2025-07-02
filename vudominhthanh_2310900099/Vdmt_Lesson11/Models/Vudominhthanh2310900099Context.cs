using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vudominnhthanh_2310900099.Models;

public partial class Vudominhthanh2310900099Context : DbContext
{
    public Vudominhthanh2310900099Context()
    {
    }

    public Vudominhthanh2310900099Context(DbContextOptions<Vudominhthanh2310900099Context> options)
        : base(options)
    {
    }

    public virtual DbSet<VdmtEmployee> VdmtEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\VUDOMINHTHANH;Database=vudominhthanh_2310900099;uid=sa;pwd=1234;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VdmtEmployee>(entity =>
        {
            entity.HasKey(e => e.VdmtEmpId);

            entity.ToTable("VdmtEmployee");

            entity.Property(e => e.VdmtEmpId)
                .HasMaxLength(50)
                .HasColumnName("vdmtEmpId");
            entity.Property(e => e.VdmtEmpLevel).HasColumnName("vdmtEmpLevel");
            entity.Property(e => e.VdmtEmpName)
                .HasMaxLength(50)
                .HasColumnName("vdmtEmpName");
            entity.Property(e => e.VdmtEmpStartDate).HasColumnName("vdmtEmpStartDate");
            entity.Property(e => e.VdmtEmpstatus).HasColumnName("vdmtEmpstatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
