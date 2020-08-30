using Deneb.Dal.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deneb.Dal.DataMaps
{
	public class ReportDataMap : IEntityTypeConfiguration<ReportDataModel>
	{
		public void Configure(EntityTypeBuilder<ReportDataModel> builder)
		{
			builder.ToTable("Reports");
			builder.HasKey(report => report.Id);

			builder.Property(report => report.Id).IsRequired();
			builder.Property(report => report.ParticipantCount).IsRequired();
			builder.Property(report => report.DateOfCreationUtc).IsRequired();
		}
	}
}
