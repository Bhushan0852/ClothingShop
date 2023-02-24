namespace ClothingShop.API.Repository.IEFRepository.Product
{
    public interface IEFProductRepository
    {
        //get product List
        Task<IEnumerable<Models.Domains.Product>> GetAll();

        //search product list
        Task<IEnumerable<Models.Domains.Product>> SearchProduct(Models.DTOs.SearchProductDTO searchProduct);

        //create product
        Task<Models.Domains.Product> CreateProduct(Models.DTOs.CreateProductDTO createProductDTO);
    }
}
