namespace KingICT.Academy.Repository.Common
{
	public class RepositoryBase
	{
		protected readonly AcademyDbContext _dbContext;

		public RepositoryBase(AcademyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
