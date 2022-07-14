namespace KingICT.Academy.Model.Project
{
	public interface IProjectRepository
	{
		Task<Project> GetProjectByIdAsync(int id);

		Task<int> CreateProjectAsync(Project project);

		Task DeleteProjectAsync(Project project);

		Task<Project> UpdateProjectAsync(Project project);

		Task<IEnumerable<Project>> GetAllProjectsAsync();
	}
}
