namespace FacilitatorProgram.Models.Data
{
    public interface IStudentsRepository
    {
        Task<List<Student>> GetStudents();

        Task<bool> CreateStudent(Student student);
        Task DeleteStudent(int studentId);
        Task<Student?> RetreiveStudent(int studentId);
        Task SaveStudent(Student student);
    }
}
