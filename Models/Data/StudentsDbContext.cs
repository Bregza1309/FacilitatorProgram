using Microsoft.EntityFrameworkCore;
namespace FacilitatorProgram.Models.Data
{
    public class StudentsDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options) { }
    }
}
