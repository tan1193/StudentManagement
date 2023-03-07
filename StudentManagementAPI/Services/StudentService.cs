using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Interfaces;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly StudentManagementAPIContext _db;
        public StudentService(StudentManagementAPIContext db)
        {
            _db = db;
        }

        public (List<Student>, int totalRow) GetStudents(int page, int pageSize, string searchString)
        {
            var students = _db.Student.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FullName.Contains(searchString) || (s.Phone ?? "").Contains(searchString)).ToList();
            }
            var totalRow = students.Count;
            students = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();


            return (students, totalRow);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _db.Student.FindAsync(id);
        }

        public async Task UpdateStudentAsync(int id, Student student)
        {
            var foundModel = await _db.Student.FindAsync(id);

            if (foundModel is null)
            {
                throw new ArgumentException($"Cannot find student with ID {id}");
            }

            _db.Update(student);

            await _db.SaveChangesAsync();
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            student.EnrollmentDate = DateTime.Now;
            _db.Student.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            if (await _db.Student.FindAsync(id) is Student student)
            {
                _db.Student.Remove(student);
                await _db.SaveChangesAsync();
                return student;
            }

            return null;
        }
    }
}
