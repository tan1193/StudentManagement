using StudentManagementAPI.Models;

namespace StudentManagementAPI.Interfaces
{
    public interface IStudentService
    {
        (List<Student>, int totalRow) GetStudents(int page, int pageSize, string searchString);
        Task<Student> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(int id, Student student);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(int id);
    }
}
