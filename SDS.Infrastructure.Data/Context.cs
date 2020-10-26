using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Infrastructure.Data
{
    public class Context : DbContext

    {
        public Context(DbContextOptions<Context> opt) : base(opt) { }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avatar>()
             .HasOne(p => p.Owner)
             .WithMany(po => po.AvatarsOwned)
             .OnDelete(DeleteBehavior.SetNull);



        }
    
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<AvatarType> AvatarTypes { get; set; }
    }
}

