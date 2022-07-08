﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingICT.Academy.Repository.ModelBuilders
{
	public class AcademyModelBuilder : IEntityTypeConfiguration<Model.Academy.Academy>
	{
		public void Configure(EntityTypeBuilder<Model.Academy.Academy> builder)
		{
			builder
				.ToTable("Academy", "dbo")
				.HasKey(e => e.Id);
		}
	}
}
