using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnsMentalHealthSolution.DAL.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace OnsMentalHealthSolution.DAL.Context
{
    public class OnsDbContext : DbContext
    {
        public OnsDbContext(DbContextOptions<OnsDbContext> options) : base(options)
        {
        }
        // NOTE: متنسوش تغيروا اسم السيرفر لو هتشغلوا الكود على جهاز تاني

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ons;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        public DbSet<User> Users { get; set; }
        public DbSet<Therapist> Therapists { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reaction> Reactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Therapist)
                .WithMany(t => t.comments)
                .HasForeignKey(c => c.TherapistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }




    }
}
