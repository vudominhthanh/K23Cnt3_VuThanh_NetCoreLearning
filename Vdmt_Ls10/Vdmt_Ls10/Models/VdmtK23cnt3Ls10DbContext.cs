using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vdmt_Ls10.Models;

public partial class VdmtK23cnt3Ls10DbContext : DbContext
{
    public VdmtK23cnt3Ls10DbContext()
    {
    }

    public VdmtK23cnt3Ls10DbContext(DbContextOptions<VdmtK23cnt3Ls10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VdmtPost> VdmtPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\VUDOMINHTHANH;Database=VdmtK23CNT3_Ls10Db;uid=sa;pwd=1234;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VdmtPost>(entity =>
        {
            entity.HasKey(e => e.Vdmtid);

            entity.ToTable("VdmtPost");

            entity.Property(e => e.Vdmtid)
                .ValueGeneratedNever()
                .HasColumnName("vdmtid");
            entity.Property(e => e.VdmtContent)
                .HasColumnType("ntext")
                .HasColumnName("vdmtContent");
            entity.Property(e => e.VdmtImage)
                .HasMaxLength(250)
                .HasColumnName("vdmtImage");
            entity.Property(e => e.VdmtStatus).HasColumnName("vdmtStatus");
            entity.Property(e => e.VdmtTitle)
                .HasMaxLength(250)
                .HasColumnName("vdmtTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
