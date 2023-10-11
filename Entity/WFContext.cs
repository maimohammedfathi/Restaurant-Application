using Microsoft.EntityFrameworkCore;
using VersionOfProject.Cofigration;

namespace VersionOfProject.Entity
{
    public class WFContext: DbContext
    {
        public WFContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Employe> Employies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminHome> AdminHomes { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=CR7\\SQLEXPRESS;Initial Catalog=CasherSyatem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfigration());
            modelBuilder.ApplyConfiguration(new DrinksConfigration());
            modelBuilder.ApplyConfiguration(new FoodConfigration());
            modelBuilder.ApplyConfiguration(new UserConfigration());
            modelBuilder.ApplyConfiguration(new CategoryFoodConfigration());
            modelBuilder.ApplyConfiguration(new DrinkCategoryConfigration());

            modelBuilder.Entity<User>().HasData(new User { Id = 1 , Email= "admin@gmail.com" , Password ="12345678RM" });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Email = "Casher@gmail.com", Password = "12345678CR7" });

        }
    }
}
