using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy.Repository.Common
{
	public class AcademyDbContext : DbContext
	{
		public virtual DbSet<Model.Academy.Academy> Academies { get; set; }

		public virtual DbSet<Model.Student.Student> Students { get; set; }


		public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademyDbContext).Assembly);
		}
	}
}
