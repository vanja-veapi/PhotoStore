using Microsoft.EntityFrameworkCore;
using PhotoAPI.DataAccess.Entities;
using PhotoStore.Domain;
using System;

namespace PhotoStore.DataAccess
{
    public class PhotoContext : DbContext
    {
        //public PhotoContext(DbContextOptions options = null) : base(options)
        //{

        //}
        public IApplicationUser User { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=PhotoStore;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            //modelBuilder.Entity<Cart>().HasKey(x => new { x.UserId });
            modelBuilder.Entity<Order>().Property(x => x.Quantity);
            modelBuilder.Entity<Order>().HasKey(x => new { x.CartId, x.CameraId });

            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
