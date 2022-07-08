namespace KingICT.Academy.Contract.Academy
{
	public interface IAcademyService
	{
		Task<AcademyDto> GetAcademyByIdAsync(int id);
	}
}
