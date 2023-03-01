using ClothingShop.API.Data;
using ClothingShop.API.Models.DTOs.User;
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
            var data = dbContext.Users.Where(x => !x.IsDeleted)
                .Include(x => x.UserRole)
                .Include(x => x.UserLocations).Where(x => !x.IsDeleted).ToList();
            

            return data;
        }

        public async Task<Models.Domains.User> GetUserLocationByUserAsync(Guid guid)
        {
            return dbContext.Users
                .Include(x => x.UserRole)
                .Include(x => x.UserLocations).FirstOrDefault(c => c.Id == guid);
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

        public async Task<Models.Domains.UserLocations> UpdateUserLocationAsync(Models.DTOs.User.UpdateUserLocationDTO userLocationDTO)
        {
            int count = 0;
            var userLocations = await dbContext.UserLocations.FirstOrDefaultAsync(x => x.Id == userLocationDTO.Id);
            if(userLocations != null)
            {
                userLocations.AddressLane1 = userLocationDTO.AddressLane1;  
                userLocations.AddressLane2 = userLocationDTO.AddressLane2;  
                userLocations.AddressLane3 = userLocationDTO.AddressLane3;  
                userLocations.PinCode = userLocationDTO.PinCode;  
                userLocations.City = userLocationDTO.City;  
                userLocations.State = userLocationDTO.State;
                userLocations.IsPrimary = userLocationDTO.IsPrimary;
                dbContext.Update(userLocations);
               count = await dbContext.SaveChangesAsync();
            }
            if(count > 0)
            {
                return userLocations;
            }
            return userLocations;
        }

        public async Task<bool> DeleteUserAsync(Guid guid)
        {
            var user = await dbContext.Users
                .Include(c => c.UserLocations)
                .FirstOrDefaultAsync(c => c.Id == guid);
            try
            {
                if (user != null)
                {
                    user.IsDeleted = true;
                    user.UpdatedBy = "Test";
                    user.UpdatedByTimeStamp = DateTime.Now.ToString();
                    dbContext.Update(user);
                    await dbContext.SaveChangesAsync();

                    foreach (var userLocation in user.UserLocations.ToList())
                    {
                        userLocation.IsDeleted = true;
                        userLocation.UpdatedBy = "Test";
                        userLocation.UpdatedByTimeStamp = DateTime.Now.ToString();
                        dbContext.Update(userLocation);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;    
        }

        public async Task<bool> DeleteUserLoacationAsync(Guid guid)
        {
            var userLocation = await dbContext.UserLocations.FirstOrDefaultAsync(c => c.Id == guid);

            try
            {
                if (userLocation.Id != Guid.NewGuid())
                {
                    userLocation.IsDeleted = true;
                    userLocation.UpdatedBy = "Test";
                    userLocation.UpdatedByTimeStamp = DateTime.Now.ToString();
                    dbContext.Update(userLocation);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Models.Domains.User> LoginUser(LoginUser loginUser)
        {
            var data = await dbContext.Users.FirstOrDefaultAsync(c => (c.Email == loginUser.Email || c.MobileNumber == loginUser.MobileNumber) 
                                                                && c.Password == loginUser.Password && !c.IsDeleted);
            if(data != null)
            {
                return data;
            }
            return data;
        }

        public async Task<Models.Domains.User> Resetpassword(LoginUser loginUser)
        {
            var result =await dbContext.Users.FirstOrDefaultAsync(c => (c.Email == loginUser.Email || c.MobileNumber == loginUser.MobileNumber)
                                                                && !c.IsDeleted);
            if(result != null)
            {
                result.Password = loginUser.Password;
                dbContext.Update(result);
                await dbContext.SaveChangesAsync();
            }
            return result;
        }


        public async Task<Models.Domains.UserLocations> UpdateUserLocationFromCartAsync(Models.DTOs.User.UpdateUserLocationFromCartDTO userLocationDTO)
        {
            int count = 0;
            var userLocations = await dbContext.UserLocations.FirstOrDefaultAsync(x => x.UserId == userLocationDTO.Id);
            if (userLocations != null)
            {
                userLocations.AddressLane1 = userLocationDTO.AddressLane1;
                userLocations.AddressLane2 = userLocationDTO.AddressLane2;
                userLocations.AddressLane3 = userLocationDTO.AddressLane3;
                userLocations.PinCode = userLocationDTO.PinCode;
                userLocations.City = userLocationDTO.City;
                userLocations.State = userLocationDTO.State;
                userLocations.IsPrimary = true;
                dbContext.Update(userLocations);
                count = await dbContext.SaveChangesAsync();
            }
            if (count > 0)
            {
                return userLocations;
            }
            return userLocations;
        }

    }
}
