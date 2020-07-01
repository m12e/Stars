using Altair.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altair.Dal.DomainMaps
{
	public class ParticipantDomainMap : IEntityTypeConfiguration<ParticipantDomainModel>
	{
		public void Configure(EntityTypeBuilder<ParticipantDomainModel> builder)
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
