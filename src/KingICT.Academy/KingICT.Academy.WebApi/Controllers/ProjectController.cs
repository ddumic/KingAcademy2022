using KingICT.Academy.Contract.Project;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy.WebApi.Controllers
{
	[ApiController, Route("api/v{version:apiVersion}/projects"), ApiVersion("1")]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProjects()
		{
			return Ok(await _projectService.GetAllProjectsAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProjectById([FromRoute] int id)
		{
			return Ok(await _projectService.GetProjectByIdAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateProject([FromBody] ProjectDto project)
		{
			return Ok(await _projectService.CreateProjectAsync(project));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProject([FromRoute] int id)
		{
			await _projectService.DeleteProjectAsync(id);

			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProject([FromRoute] int id, [FromBody] ProjectDto project)
		{
			if (id != project.Id)
			{
				throw new ArgumentException(nameof(id));
			}

			return Ok(await _projectService.UpdateProjectAsync(project));
		}
	}
}
