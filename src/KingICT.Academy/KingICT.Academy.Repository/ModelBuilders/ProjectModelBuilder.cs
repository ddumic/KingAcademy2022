using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingICT.Academy.Repository.ModelBuilders
{
	public class ProjectModelBuilder : IEntityTypeConfiguration<Model.Project.Project>
	{
		public void Configure(EntityTypeBuilder<Model.Project.Project> builder)
		{
			builder
				.ToTable("Project", "dbo")
				.HasKey(e => e.Id);

			builder
				.HasMany(e => e.Students)
				.WithOne(e => e.Project)
				.HasForeignKey(e => e.ProjectId);
		}
	}
}
