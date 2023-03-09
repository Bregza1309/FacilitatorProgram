using Microsoft.EntityFrameworkCore;

namespace FacilitatorProgram.Models.Data
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly StudentsDbContext db;
        public StudentsRepository(StudentsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateStudent(Student student)
        {
            Student? exist = db.Students.SingleOrDefault(stud => stud.LastName == student.LastName && stud.FirstName == student.FirstName);
            if (exist == null)
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task DeleteStudent(int studentId)
        {
            Student? student = await db.Students.SingleOrDefaultAsync(student => student.StudentId == studentId);
            if(student != null)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                
            }
        }

        public async Task<List<Student>> GetStudents() => await db.Students.ToListAsync();

        public async Task<Student?> RetreiveStudent(int studentId)
        {
            return await db.Students.SingleOrDefaultAsync(student => student.StudentId == studentId);
        }

        public async Task SaveStudent(Student student)
        {
            ;
            await db.SaveChangesAsync();
        }
    }
}
