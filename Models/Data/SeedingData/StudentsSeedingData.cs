using FacilitatorProgram.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FacilitatorProgram.Models.Data.SeedingData
{
    public static class StudentsSeedingData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            StudentsDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StudentsDbContext>();
            if((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }

            if (!context.Students.Any())
            {
                Student[] InitialStudents = { new() { FirstName = "Isaac" ,LastName = "Nel",Address1="140 Smit Avenue Vereeniging",Address2 = "6 Kaven cort Johannesburg" ,Email = "1001@ctucareer.co.za"},
                new() { FirstName = "Jason" ,LastName = "Smith",Address1="45 Elgn Street",Address2 = "7 Jeppe Johannesburg" ,Email = "1002@ctucareer.co.za"}
                };
                foreach (Student student in InitialStudents)
                {
                    await context.Students.AddAsync(student);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
