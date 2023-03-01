namespace ClothingShop.API.Repository.IEFRepository.User
{
    public interface IEFUserRepository
    {
        //Login User id
        Task<Models.Domains.User> LoginUser(Models.DTOs.User.LoginUser loginUser);

        //Reset Password
        Task<Models.Domains.User> Resetpassword(Models.DTOs.User.LoginUser loginUser);

        //GetALL Users
        Task<IEnumerable<Models.Domains.User>> GetAllAsnyc();
        //get user location by userid
        Task<Models.Domains.User> GetUserLocationByUserAsync(Guid guid);

        //add user
        Task<Models.Domains.User> CreateAsync(Models.DTOs.User.CreateUserDTO createUserDTO);

        //add user location
        Task<Models.Domains.UserLocations> CreateLocationAsync(Models.DTOs.User.CreateUserLocationsDTO createUserLocation);


        //edit user location details
        Task<Models.Domains.UserLocations> UpdateUserLocationAsync(Models.DTOs.User.UpdateUserLocationDTO userLocationDTO);

        //delete user
        Task<bool> DeleteUserAsync(Guid guid);

        //delete userlocation
        Task<bool> DeleteUserLoacationAsync(Guid guid);

        //edit user location details from cart screen
        Task<Models.Domains.UserLocations> UpdateUserLocationFromCartAsync(Models.DTOs.User.UpdateUserLocationFromCartDTO userLocationDTO);
    }
}
