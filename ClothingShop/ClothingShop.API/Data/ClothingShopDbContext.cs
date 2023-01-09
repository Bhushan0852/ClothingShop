using ClothingShop.API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.API.Data
{
    public class ClothingShopDbContext : DbContext
    {
        public ClothingShopDbContext(DbContextOptions<ClothingShopDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLocations> UserLocations{ get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
