using KingICT.Academy.Model.Project;
using KingICT.Academy.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy.Repository.Project
{
	public class ProjectRepository : RepositoryBase, IProjectRepository
	{
		public ProjectRepository(AcademyDbContext dbContext)
			: base(dbContext)
		{ }

		public async Task<int> CreateProjectAsync(Model.Project.Project project)
		{
			await _dbContext.Projects.AddAsync(project);
			await _dbContext.SaveChangesAsync();

			return project.Id;
		}

		public async Task DeleteProjectAsync(Model.Project.Project project)
		{
			_dbContext.Projects.Remove(project);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Model.Project.Project>> GetAllProjectsAsync()
		{
			return await _dbContext.Projects
				.Include(x => x.Students)
				.ToListAsync();
		}

		public async Task<Model.Project.Project> GetProjectByIdAsync(int id)
		{
			return await _dbContext.Projects
				.Include(x => x.Students)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Model.Project.Project> UpdateProjectAsync(Model.Project.Project project)
		{
			_dbContext.Projects.Update(project);
			await _dbContext.SaveChangesAsync();

			return project;
		}
	}
}
