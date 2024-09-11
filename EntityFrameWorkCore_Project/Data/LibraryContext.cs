using System;
using System.Collections.Generic;
using EntityFrameWorkCore_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_Project.Datas;
public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {

    }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Lib> Libs { get; set; }

    public virtual DbSet<SCard> SCards { get; set; }

    public virtual DbSet<TCard> TCards { get; set; }
    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Press> Presses { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NB7MT4D\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasMaxLength(50);
            entity.Property(e => e.IdAuthor).HasColumnName("Id_Author");
            entity.Property(e => e.IdCategory).HasColumnName("Id_Category");
            entity.Property(e => e.IdPress).HasColumnName("Id_Press");
            entity.Property(e => e.IdThemes).HasColumnName("Id_Themes");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Lib>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(25);
        });

        modelBuilder.Entity<SCard>(entity =>
        {
            entity.ToTable("S_Cards", tb =>
                {
                    tb.HasTrigger("CheckQuantity");
                    tb.HasTrigger("DontGiveBook");
                    tb.HasTrigger("Trigger_ForQuantityIncr");
                    tb.HasTrigger("trg_RestrictBookOver");
                    tb.HasTrigger("trg_RestrictBookOver1");
                });

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
            entity.Property(e => e.IdLib).HasColumnName("Id_Lib");
            entity.Property(e => e.IdStudent).HasColumnName("Id_Student");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Book");

            entity.HasOne(d => d.IdLibNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdLib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Lib");
        });

        modelBuilder.Entity<TCard>(entity =>
        {
            entity.ToTable("T_Cards", tb =>
                {
                    tb.HasTrigger("Trigger_ForQuantityIncrT_Cards");
                    tb.HasTrigger("trg_UpdateBookQuantityOnReturn_T_Card11");
                    tb.HasTrigger("trg_UpdateBookQuantityOnReturn_T_Card1189");
                });

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
            entity.Property(e => e.IdLib).HasColumnName("Id_Lib");
            entity.Property(e => e.IdTeacher).HasColumnName("Id_Teacher");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Book");

            entity.HasOne(d => d.IdLibNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdLib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Lib");


            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(15);
                entity.Property(e => e.LastName).HasMaxLength(25);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Press>(entity =>
            {
                entity.ToTable("Press");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(30);
            });

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
