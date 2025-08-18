using StudentService.Models;

namespace StudentService.Service
{
    public interface IStudentRepository
    {
        IEnumerable<Student?> GetStudents();
        Student? GetStudent(int id);
    }
}
