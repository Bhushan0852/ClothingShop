using ClothingShop.API.Data;
using ClothingShop.API.IEFRepository.Category;
using ClothingShop.API.Models.Domains;
using ClothingShop.API.Models.DTOs.Category;

namespace ClothingShop.API.EFRepository.Category
{
    public class EFCategoryRepository : IEFCategoryRepository
    {

        private readonly ClothingShopDbContext dbContext;
        public EFCategoryRepository(ClothingShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Models.Domains.Product>> GetProductsbySearch(string searchProduct)
        {
            var data = dbContext.Products.Where(C => !C.IsDeleted).ToList();
            //var products = new List<Product>();
            foreach (var item in data)
            {
                //Product product = new Product();
                //product = item;
                item.ProductBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == item.ProductBrandId);
                item.ProductColour = dbContext.ProductColours.FirstOrDefault(x => x.Id == item.ProductColourId);
                item.ProductSize = dbContext.ProductSizes.FirstOrDefault(x => x.Id == item.ProductSizeId);
                //products.Add(product);
            }
            data = data.Where(z => z.ProductBrand.BrandCode.ToLower() == searchProduct.ToLower()).ToList();
            return data;
        }
        public async  Task<IEnumerable<Models.Domains.Product>> GetProductList(SearchCategory searchCategory)
        {
            IEnumerable<Models.Domains.Product> products = new List<Models.Domains.Product>();
            var data = dbContext.Products.Where(x => !x.IsDeleted).ToList();
            if(searchCategory.ProductBrandId != null)
            {
                data = data.Where(c => (searchCategory.ProductBrandId.Value == c.ProductBrandId) ||
                                           (searchCategory.ProductColourId.Value == c.ProductColourId) ||
                                           (searchCategory.ProductSizeId.Value == c.ProductSizeId)).ToList();
            }

            if (products == null)
            {
                return null;
            }
            return data;
        }

        public async Task<Models.Domains.Product> GetProductPreview(Guid guid)
        {
            var data = dbContext.Products.Where(c => c.Id == guid && !c.IsDeleted).FirstOrDefault();

            Models.Domains.Product product = new Models.Domains.Product();
            product = data;
            product.ProductBrand = dbContext.ProductBrands.FirstOrDefault(x => x.Id == data.ProductBrandId);
            product.ProductColour = dbContext.ProductColours.FirstOrDefault(x => x.Id == data.ProductColourId);
            product.ProductSize = dbContext.ProductSizes.FirstOrDefault(x => x.Id == data.ProductSizeId);

            return product;
        }
    }
}
