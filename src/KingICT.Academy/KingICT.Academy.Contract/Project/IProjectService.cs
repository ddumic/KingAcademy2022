namespace KingICT.Academy.Contract.Project
{
	public interface IProjectService
	{
		Task<ProjectDto> GetProjectByIdAsync(int id);

		Task<ProjectDto> CreateProjectAsync(ProjectDto project);

		Task DeleteProjectAsync(int id);

		Task<ProjectDto> UpdateProjectAsync(ProjectDto project);

		Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
	}
}
