using Microsoft.AspNetCore.Identity;
using FacilitatorProgram.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace FacilitatorProgram.Models.Data.SeedingData
{
    public static class IdentitySeedData
    {
        public async static Task EnsurePopulated(IApplicationBuilder app)
        {
            //check if there are any migrations pending
            FacilitatorDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<FacilitatorDbContext>();
            if( (await context.Database.GetPendingMigrationsAsync()).Any())
            {
               await context.Database.MigrateAsync();
            }
            //Populate the database with some facilitators
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = new() { UserName = "Bregza1309" };

            IdentityUser existing = await userManager.FindByNameAsync(user.UserName);
            if (existing == null) {
                await userManager.CreateAsync(user,"Pa$$w0rd");
            }



        }
    }
}
