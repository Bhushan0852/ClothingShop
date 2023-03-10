namespace ClothingShop.API.Repository.IEFRepository.Product
{
    public interface IEFProductRepository
    {
        //get product List
        Task<IEnumerable<Models.Domains.Product>> GetAllAsync();

        //search product by skuName
        Task<Models.Domains.Product> SearchSkuProducts(string skuName);

        //create product
        Task<bool> CreateProduct(Models.DTOs.CreateProductDTO createProductDTO, List<IFormFile> fileData);

        //product preview for customer and vendor
        Task<Models.Domains.Product> GetProductPreview(Guid guid);

        //get product detail for edit/ get product detail for Clone 
        Task<Models.Domains.Product> GetProductDetail(Guid guid);

        //remove product
        Task<bool> RemoveProduct(Guid guid);

        //update product
        Task<Models.Domains.Product> UpdateProduct(Models.DTOs.UpdateProductDTO updateProductDTO);

        //create clone product
        Task<Models.Domains.Product> CreateCloneProduct(Models.DTOs.CreateProductDTO createProductDTO);

        //User added Product
        Task<bool> UserAddedProduct(Guid userId, Guid productId, int Qty);

        //Remove User added Product
        Task<bool> RemoveUserAddedProduct(Guid userId, Guid productId);

        //Placed order
        Task<bool> PlaceOrder(Guid userId, Guid productId);
    }
}
