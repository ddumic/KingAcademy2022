using KingICT.Academy.Contract.Academy;
using KingICT.Academy.Model.Academy;

namespace KingICT.Academy.Service.Academy
{
	public class AcademyService : IAcademyService
	{
		private readonly IAcademyRepository _academyRepository;

		public AcademyService(IAcademyRepository academyRepository)
		{
			_academyRepository = academyRepository;
		}

		public async Task<AcademyDto> GetAcademyByIdAsync(int id)
		{
			var academy = await _academyRepository.GetAcademyByIdAsync(id);

			return new AcademyDto
			{
				Name = academy.Name,
				Id = academy.Id
			};
		}
	}
}
