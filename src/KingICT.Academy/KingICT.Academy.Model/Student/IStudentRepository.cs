namespace KingICT.Academy.Model.Student
{
	public interface IStudentRepository
	{
		Task<Student> GetStudentByIdAsync(int id);

		Task<int> CreateStudentAsync(Student student);

		Task DeleteStudentAsync(Student student);

		Task<Student> UpdateStudentAsync(Student student);

		Task<IEnumerable<Student>> GetAllStudentsAsync();
	}
}
