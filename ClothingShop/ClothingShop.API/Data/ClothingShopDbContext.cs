using ClothingShop.API.Models.Domains;
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
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductBrands> ProductBrands{ get; set; }
        public DbSet<ProductColour> ProductColours{ get; set; }
        public DbSet<ProductImages> ProductImages{ get; set; }
        public DbSet<UserProducts> UserProducts{ get; set; }

        public DbSet<ImageModel> Images { get; set; }
        public DbSet<FileDetails> FileDetails{ get; set; }
    }
}
