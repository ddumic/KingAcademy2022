using KingICT.Academy.Model.Academy;
using KingICT.Academy.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy.Repository.Academy
{
	public class AcademyRepository : IAcademyRepository
	{
		private readonly AcademyDbContext _dbContext;

		public AcademyRepository(AcademyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Model.Academy.Academy> GetAcademyByIdAsync(int id)
		{
			return await _dbContext.Academies.FirstOrDefaultAsync(a => a.Id == id);
		}
	}
}
