using Deneb.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deneb.Dal.DomainMaps
{
	public class ReportDomainMap : IEntityTypeConfiguration<ReportDomainModel>
	{
		public void Configure(EntityTypeBuilder<ReportDomainModel> builder)
		{
			builder.ToTable("Reports");
			builder.HasKey(report => report.Id);

			builder.Property(report => report.Id).IsRequired();
			builder.Property(report => report.ParticipantCount).IsRequired();
			builder.Property(report => report.DateOfCreationUtc).IsRequired();
		}
	}
}
