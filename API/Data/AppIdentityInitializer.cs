using System;
using API.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
	public class AppIdentityInitializer
	{
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            /// check whether any user have been created
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ray",
                    Email = "ray@email.com",
                    UserName = "ray@email.com",
                    Address = new Address
                    {
                        FirstName = "Ray",
                        LastName = "Le",
                        Street = "111 NTMK, district 1",
                        City = "Ho Chi Minh",
                        State = "Viet Nam",
                        ZipCode = "70000"
                    }
                };

                await userManager.CreateAsync(user, "password");

            }
        }
    }
}

