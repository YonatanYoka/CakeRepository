using CakesData.Model;
using Microsoft.EntityFrameworkCore;

namespace CakesData.DataAccess
{
    public class DBContext: DbContext
    {
       // public DbSet<Inventory> Inventory{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cake> Cakes{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses{ get; set; }
        // public DbSet<UserType> UserTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CakeDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
