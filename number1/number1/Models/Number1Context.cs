using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using number1.Models;

namespace number1.Models;

public partial class Number1Context : IdentityDbContext<User>
{
    public Number1Context()
    {
    }

    public Number1Context(DbContextOptions<Number1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<CardInfo> CardInfos { get; set; }

    public virtual DbSet<UserCard> UserCards { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Album>(entity =>
        {
            entity.ToTable("album");

            entity.Property(e => e.AlbumId).UseIdentityColumn();

            entity.Property(e => e.AlbumName)
                .HasMaxLength(50)
                .HasColumnName("albumName");
            entity.Property(e => e.Description).HasColumnName("description");

        });

        modelBuilder.Entity<CardInfo>(entity =>
        {
            entity.HasKey(e => e.CardId);

            entity.ToTable("cardInfo");

            entity.Property(e => e.CardId)
                .ValueGeneratedNever()
                .HasColumnName("cardId");
            entity.Property(e => e.AlbumId).HasColumnName("albumId");
            entity.Property(e => e.CardImage).HasColumnName("cardImage");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.ExistsQuantity).HasColumnName("existsQuantity");
            entity.Property(e => e.NameCard)
                .HasMaxLength(250)
                .HasColumnName("nameCard");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rate).HasColumnName("rate");

            entity.HasOne(d => d.Album).WithMany(p => p.CardInfos)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_cardInfo_album");
        });

        modelBuilder.Entity<UserCard>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CardId }).HasName("PK__UserCard__CF4FA0B6869B9054");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CardId).HasColumnName("cardId");
            entity.Property(e => e.OwnQuantity)
                .HasDefaultValue(1)
                .HasColumnName("ownQuantity");

            entity.HasOne(d => d.Card).WithMany(p => p.UserCards)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserCards__cardI__4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.UserCards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserCards__userI__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
