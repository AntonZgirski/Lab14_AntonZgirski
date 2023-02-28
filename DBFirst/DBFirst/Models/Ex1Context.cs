using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models;

public partial class Ex1Context : DbContext
{
    public Ex1Context()
    {
    }

    public Ex1Context(DbContextOptions<Ex1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<VlistPlayerOnTeam> VlistPlayerOnTeams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=USERPC;Initial Catalog=EX1;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity.ToTable("Coach");

            entity.Property(e => e.CoachId).HasColumnName("CoachID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player", tb => tb.HasTrigger("update_salary_player"));

            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_Team");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.CoachId).HasColumnName("CoachID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Coach).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Coach");
        });

        modelBuilder.Entity<VlistPlayerOnTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VListPlayerOnTeam");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
