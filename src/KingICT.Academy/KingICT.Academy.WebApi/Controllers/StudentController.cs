using KingICT.Academy.Contract.Student;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy.WebApi.Controllers
{
	[ApiController, Route("api/v{version:apiVersion}/students"), ApiVersion("1")]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllStudents()
		{
			return Ok(await _studentService.GetAllStudentsAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetStudentById(int id)
		{
			return Ok(await _studentService.GetStudentByIdAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateStudent(StudentDto student)
		{
			return Ok(await _studentService.CreateStudentAsync(student));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			await _studentService.DeleteStudentAsync(id);

			return Ok();
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateStudent(int id, StudentDto student)
		{
			if (id != student.Id)
			{
				throw new ArgumentException(nameof(id));
			}

			return Ok(_studentService.UpdateStudentAsync(student));
		}
	}
}
