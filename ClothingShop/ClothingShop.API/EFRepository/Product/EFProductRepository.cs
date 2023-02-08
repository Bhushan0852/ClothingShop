using ClothingShop.API.Data;
using ClothingShop.API.Repository.IEFRepository.Product;

namespace ClothingShop.API.Repository.Repository.Product
{
    public class EFProductRepository : IEFProductRepository
    {
        private readonly ClothingShopDbContext dbContext;

        public EFProductRepository(ClothingShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Models.Domains.Product>> GetAll()
        {
            var data = dbContext.Products.Where(C => !C.IsDeleted).ToList();

            return data;
        }
    }
}
