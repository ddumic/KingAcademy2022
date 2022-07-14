namespace KingICT.Academy.Contract.Project
{
	public class ProjectDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<Student.StudentDto> Students { get; set; }
	}
}
