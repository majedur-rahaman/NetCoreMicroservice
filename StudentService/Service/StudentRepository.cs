using StudentService.Models;

namespace StudentService.Service
{
    public class StudentRepository : IStudentRepository
    {
        public Student? GetStudent(int id)
        {
            return _students.Find(x => x.Id == id);
        }

        public IEnumerable<Student?> GetStudents()
        {
            return _students.ToList();
        }
        public static List<Student> _students = StudentSeed();

        private static List<Student> StudentSeed()
        {
            var students = new List<Student>()
            {
                new Student{Id=1, Name="Kamal", Roll=10,Class="Ten"},
                new Student{Id=2, Name="Jamal", Roll=10,Class="Nine"},
                new Student{Id=3, Name="Jolil", Roll=1,Class="Ten"},
                new Student{Id=4, Name="Rofique",Roll=10,Class="Seven"},
                new Student{Id=5, Name="Nupur", Roll=7,Class="Eight"}
            };
            return students;
        }
    }
}
