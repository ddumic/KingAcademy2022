namespace KingICT.Academy.Contract.Student
{
	public interface IStudentService
	{
		Task<StudentDto> GetStudentByIdAsync(int id);

		Task<StudentDto> CreateStudentAsync(StudentDto student);

		Task DeleteStudentAsync(int id);

		Task<StudentDto> UpdateStudentAsync(StudentDto student);

		Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
	}
}
