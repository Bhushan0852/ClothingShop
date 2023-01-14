namespace ClothingShop.API.Repository.IEFRepository.User
{
    public interface IEFUserRepository
    {
        //GetALL Users
        Task<IEnumerable<Models.Domains.User>> GetAllAsnyc();

        Task<Models.Domains.User> CreateAsync(Models.DTOs.User.CreateUserDTO createUserDTO);

        Task<Models.Domains.UserLocations> CreateLocationAsync(Models.DTOs.User.CreateUserLocationsDTO createUserLocation);
    }
}
