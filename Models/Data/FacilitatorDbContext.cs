using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FacilitatorProgram.Models.Data
{
    public class FacilitatorDbContext:IdentityDbContext<IdentityUser>
    {
        public FacilitatorDbContext(DbContextOptions<FacilitatorDbContext> options) : base(options) { }
    }
}
