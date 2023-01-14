using ClothingShop.API.Data;
using ClothingShop.API.Repository.IEFRepository.User;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.API.Repository.Repository.User
{
    public class EFUserRepository : IEFUserRepository
    {
        private readonly ClothingShopDbContext dbContext;

        public EFUserRepository(ClothingShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Models.Domains.User> CreateAsync(Models.DTOs.User.CreateUserDTO createUserDTO)
        {
            Models.Domains.User user = new Models.Domains.User();
            user.Id = Guid.NewGuid();
            user.FirstName = createUserDTO.FirstName;
            user.LastName = createUserDTO.LastName;
            user.Email = createUserDTO.Email;
            user.Password = createUserDTO.Password;
            user.UserRoleId = createUserDTO.UserRoleId;
            user.CreatedBy = "test";// createUserDTO.CreatedBy;
            user.UpdatedBy = "";// createUserDTO.CreatedBy;
            user.CreatedByTimeStamp = DateTime.Now.ToString();
            user.UpdatedByTimeStamp = "";
            var usId =await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            //if (!string.IsNullOrEmpty(usId.Entity.Id.ToString()))
            if (usId.Entity.Id != Guid.Empty)
            {
                Models.Domains.UserLocations userLocations = new Models.Domains.UserLocations();
                userLocations.Id = Guid.NewGuid();
                userLocations.AddressLane1 = createUserDTO.CreateUserLocation.AddressLane1;
                userLocations.AddressLane2 = createUserDTO.CreateUserLocation.AddressLane2;
                userLocations.AddressLane3 = createUserDTO.CreateUserLocation.AddressLane3;
                userLocations.PinCode = createUserDTO.CreateUserLocation.PinCode;
                userLocations.State = createUserDTO.CreateUserLocation.State;
                userLocations.City = createUserDTO.CreateUserLocation.City;
                userLocations.IsPrimary = true;
                userLocations.UserId = usId.Entity.Id;
                userLocations.CreatedBy = "test";
                userLocations.UpdatedBy = "";
                userLocations.CreatedByTimeStamp = DateTime.Now.ToString();
                userLocations.UpdatedByTimeStamp = "";
                await dbContext.UserLocations.AddAsync(userLocations);
                await dbContext.SaveChangesAsync();
            }
            return user;
        }

        public async Task<IEnumerable<Models.Domains.User>> GetAllAsnyc()
        {
            var data = dbContext.Users.Include(x => x.UserRole).Include(x => x.UserLocations).ToList();
            return data;
        }

        public async Task<Models.Domains.UserLocations> CreateLocationAsync(Models.DTOs.User.CreateUserLocationsDTO userLocationsDTO)
        {
            Models.Domains.UserLocations userLocations = new Models.Domains.UserLocations();
            userLocations.AddressLane1 = userLocationsDTO.AddressLane1;
            userLocations.AddressLane2 = userLocationsDTO.AddressLane2; 
            userLocations.AddressLane3 = userLocationsDTO.AddressLane3;
            userLocations.City = userLocationsDTO.City; 
            userLocations.State = userLocationsDTO.State;   
            userLocations.PinCode = userLocationsDTO.PinCode;
            userLocations.IsPrimary = false;
            userLocations.UserId = userLocationsDTO.UserId;
            userLocations.CreatedBy = "Test";
            userLocations.CreatedByTimeStamp = DateTime.Now.ToString();
            userLocations.UpdatedBy = "";
            userLocations.UpdatedByTimeStamp = "";
            var data = await dbContext.UserLocations.AddAsync(userLocations);
            await dbContext.SaveChangesAsync();

            if(data.Entity.Id == Guid.Empty)
            {
                return new Models.Domains.UserLocations();
            }
            return data.Entity;
        }
    }
}
