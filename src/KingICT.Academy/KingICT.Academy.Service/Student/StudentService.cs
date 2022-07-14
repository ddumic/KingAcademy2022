using KingICT.Academy.Contract.Student;
using KingICT.Academy.Model.Student;

namespace KingICT.Academy.Service.Student
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;

		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public async Task<StudentDto> GetStudentByIdAsync(int id)
		{
			var student = await _studentRepository.GetStudentByIdAsync(id);

			return new StudentDto
			{
				FirstName = student.FirstName,
				LastName = student.LastName,
				Id = student.Id
			};
		}

		public async Task<StudentDto> CreateStudentAsync(StudentDto student)
		{
			var s = new Model.Student.Student();
			s.SetFirstName(student.FirstName);
			s.SetLastName(student.LastName);
			s.SetId(await _studentRepository.CreateStudentAsync(s));

			return new StudentDto
			{
				Id = s.Id,
				FirstName = s.FirstName,
				LastName = s.LastName
			};
		}

		public async Task DeleteStudentAsync(int id)
		{
			var s = await _studentRepository.GetStudentByIdAsync(id);

			if (s is null)
			{
				throw new ArgumentException(nameof(id));
			}

			await _studentRepository.DeleteStudentAsync(s);
		}

		public async Task<StudentDto> UpdateStudentAsync(StudentDto student)
		{
			var s = await _studentRepository.GetStudentByIdAsync(student.Id);

			if (s is null)
			{
				throw new ArgumentException(nameof(student.Id));
			}

			s.SetFirstName(student.FirstName);
			s.SetLastName(student.LastName);

			var updatedStudent = await _studentRepository.UpdateStudentAsync(s);

			return new StudentDto
			{
				Id = updatedStudent.Id,
				FirstName = updatedStudent.FirstName,
				LastName = updatedStudent.LastName
			};
		}

		public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
		{
			var result = new List<StudentDto>();

			var students = await _studentRepository.GetAllStudentsAsync();

			foreach (var student in students)
			{
				result.Add(new StudentDto
				{
					Id = student.Id,
					FirstName = student.FirstName,
					LastName = student.LastName
				});
			}

			return result;
		}
	}
}
