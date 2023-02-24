using ClothingShop.API.Data;
using ClothingShop.API.Models.DTOs;
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

        public Task<Models.Domains.Product> CreateProduct(CreateProductDTO createProductDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Domains.Product>> GetAll()
        {
            var data = dbContext.Products.Where(C => !C.IsDeleted).ToList();

            return data;
        }

        public async Task<IEnumerable<Models.Domains.Product>> SearchProduct(Models.DTOs.SearchProductDTO searchProduct)
        {
            List<Models.Domains.Product> products = new List<Models.Domains.Product>();
            //var data = dbContext.Products.Where(e => e.ProductName == searchProduct.ProductName).ToList();
            //List<Models.Domains.Product> products = new List<Models.Domains.Product>();
            //foreach (var product in data)
            //{
            //    Models.Domains.Product product1 = new Models.Domains.Product(); 
            //    product1.ProductName = product.ProductName; 
            //    product1.ProductDescription = product.ProductDescription; 
            //    product1.ProductPrice = product.ProductPrice;
            //    products.Add(product1);
            //}
            //if(products.Count == 0)
            //{
            //    products = new();   
            //}
            //else
            //{
            //    products =  products.OrderBy(e => e.ProductName).ToList();   
            //}
            return products;
        }
    }
}
