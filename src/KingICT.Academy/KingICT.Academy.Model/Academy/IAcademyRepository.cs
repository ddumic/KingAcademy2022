namespace KingICT.Academy.Model.Academy
{
	public interface IAcademyRepository
	{
		Task<Academy> GetAcademyByIdAsync(int id);
	}
}
