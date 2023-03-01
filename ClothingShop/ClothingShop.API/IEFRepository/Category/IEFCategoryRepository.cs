namespace ClothingShop.API.IEFRepository.Category
{
    public interface IEFCategoryRepository
    {
        Task<IEnumerable<Models.Domains.Product>> GetProductsbySearch(string searchProduct);

        Task<IEnumerable<Models.Domains.Product>> GetProductList(Models.DTOs.Category.SearchCategory searchCategory);

        
        Task<Models.Domains.Product> GetProductPreview(Guid guid);
    }
}
