namespace ClothingShop.API.Repository.IEFRepository.Product
{
    public interface IEFProductRepository
    {
        //get product List
        Task<IEnumerable<Models.Domains.Product>> GetAll();
    }
}
