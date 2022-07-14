using KingICT.Academy.Contract.Project;
using KingICT.Academy.Model.Project;
using KingICT.Academy.Model.Student;

namespace KingICT.Academy.Service.Project
{
	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IStudentRepository _studentRepository;

		public ProjectService(IProjectRepository projectRepository, IStudentRepository studentRepository)
		{
			_projectRepository = projectRepository;
			_studentRepository = studentRepository;
		}

		public async Task<ProjectDto> CreateProjectAsync(ProjectDto project)
		{
			var p = new Model.Project.Project();
			p.SetName(project.Name);

			var students = new List<Model.Student.Student>();
			foreach (var student in project.Students)
			{
				var s = await _studentRepository.GetStudentByIdAsync(student.Id);

				students.Add(s);
			}

			p.SetStudents(students);
			p.SetId(await _projectRepository.CreateProjectAsync(p));

			return new ProjectDto
			{
				Id = p.Id,
				Name = p.Name,
				Students = p.Students.Select(x => new Contract.Student.StudentDto { FirstName = x.FirstName, Id = x.Id, LastName = x.LastName })
			};
		}

		public async Task DeleteProjectAsync(int id)
		{
			var p = await _projectRepository.GetProjectByIdAsync(id);

			if (p is null)
			{
				throw new ArgumentException(nameof(id));
			}

			await _projectRepository.DeleteProjectAsync(p);
		}

		public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
		{
			var result = new List<ProjectDto>();

			var projects = await _projectRepository.GetAllProjectsAsync();

			foreach (var project in projects)
			{
				result.Add(new ProjectDto
				{
					Id = project.Id,
					Name = project.Name,
					Students = project.Students.Select(x => new Contract.Student.StudentDto { FirstName = x.FirstName, Id = x.Id, LastName = x.LastName })
				});
			}

			return result;
		}

		public async Task<ProjectDto> GetProjectByIdAsync(int id)
		{
			var project = await _projectRepository.GetProjectByIdAsync(id);

			return new ProjectDto
			{
				Id = project.Id,
				Name = project.Name,
				Students = project.Students.Select(x => new Contract.Student.StudentDto { FirstName = x.FirstName, Id = x.Id, LastName = x.LastName })
			};
		}

		public async Task<ProjectDto> UpdateProjectAsync(ProjectDto project)
		{
			var p = await _projectRepository.GetProjectByIdAsync(project.Id);

			if (p is null)
			{
				throw new ArgumentException(nameof(project.Id));
			}

			p.SetName(project.Name);

			var students = new List<Model.Student.Student>();
			foreach (var student in project.Students)
			{
				var s = new Model.Student.Student();
				s.SetLastName(student.LastName);
				s.SetFirstName(student.FirstName);
				s.SetId(student.Id);

				students.Add(s);
			}

			p.SetStudents(students);

			var updatedStudent = await _projectRepository.UpdateProjectAsync(p);

			return new ProjectDto
			{
				Id = updatedStudent.Id,
				Name = updatedStudent.Name,
				Students = updatedStudent.Students.Select(x => new Contract.Student.StudentDto { FirstName = x.FirstName, Id = x.Id, LastName = x.LastName })
			};
		}
	}
}
