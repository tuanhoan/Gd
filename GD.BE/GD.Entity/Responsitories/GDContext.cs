﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using GD.Entity.Tables;
using Microsoft.EntityFrameworkCore;

namespace GD.Entity.Responsitories
{
    public partial class GDContext : DbContext
    {
        public GDContext()
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public GDContext(DbContextOptions<GDContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}