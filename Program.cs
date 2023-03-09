using Microsoft.AspNetCore.Identity;
using FacilitatorProgram.Models.Data.SeedingData;
using FacilitatorProgram.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add Identity Services
builder.Services.AddDbContext<FacilitatorDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("FacilitatorsIdentity")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<FacilitatorDbContext>();

//Add StudentsDb EF Service
builder.Services.AddDbContext<StudentsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StudentsDb")));

//add IStudentsRepository Service
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Ensure there is at least one registered user
await IdentitySeedData.EnsurePopulated(app);
await StudentsSeedingData.EnsurePopulated(app);
app.Run();
