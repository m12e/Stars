using Altair.Dal.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altair.Dal.DataMaps
{
	public class ParticipantDataMap : IEntityTypeConfiguration<ParticipantDataModel>
	{
		public void Configure(EntityTypeBuilder<ParticipantDataModel> builder)
		{
			builder.ToTable("Participants");
			builder.HasKey(participant => participant.Id);

			builder.Property(participant => participant.Id).IsRequired();
			builder.Property(participant => participant.LastName).HasMaxLength(64).IsRequired();
			builder.Property(participant => participant.FirstName).HasMaxLength(64).IsRequired();
			builder.Property(participant => participant.Patronymic).HasMaxLength(64).IsRequired();
			builder.Property(participant => participant.Age).IsRequired();
			builder.Property(participant => participant.PersonalCode).HasMaxLength(32).IsRequired(false);
		}
	}
}
