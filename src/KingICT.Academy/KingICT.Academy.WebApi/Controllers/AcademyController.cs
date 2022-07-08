using KingICT.Academy.Contract.Academy;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy.WebApi.Controllers
{
	[ApiController, Route("api/v{version:apiVersion}/academies"), ApiVersion("1")]
	public class AcademyController : ControllerBase
	{
		private readonly IAcademyService _academyService;

		public AcademyController(IAcademyService academyService)
		{
			_academyService = academyService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAcademyById(int id)
		{
			return Ok(await _academyService.GetAcademyByIdAsync(id));
		}
	}
}
