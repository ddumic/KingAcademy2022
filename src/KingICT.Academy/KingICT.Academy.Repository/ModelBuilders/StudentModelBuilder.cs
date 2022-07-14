using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingICT.Academy.Repository.ModelBuilders
{
	public class StudentModelBuilder : IEntityTypeConfiguration<Model.Student.Student>
	{
		public void Configure(EntityTypeBuilder<Model.Student.Student> builder)
		{
			builder
				.ToTable("Student", "dbo")
				.HasKey(e => e.Id);
		}
	}
}
