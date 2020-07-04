using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vega.Dal.DomainModels;

namespace Vega.Dal.DomainMaps
{
	public class UserAccountDomainMap : IEntityTypeConfiguration<UserAccountDomainModel>
	{
		public void Configure(EntityTypeBuilder<UserAccountDomainModel> builder)
		{
			builder.ToTable("UserAccounts");
			builder.HasKey(userAccount => userAccount.Id);
			builder.HasIndex(userAccount => userAccount.Login).IsUnique();
			builder.HasIndex(userAccount => userAccount.Guid).IsUnique();

			builder.Property(userAccount => userAccount.Id).IsRequired();
			builder.Property(userAccount => userAccount.Login).HasMaxLength(32).IsRequired();
			builder.Property(userAccount => userAccount.PasswordHash).HasMaxLength(256).IsRequired();
			builder.Property(userAccount => userAccount.Guid).IsRequired();
			builder.Property(userAccount => userAccount.Status).IsRequired();
			builder.Property(userAccount => userAccount.DateOfCreationUtc).IsRequired();
			builder.Property(userAccount => userAccount.DateOfLastChangeUtc).IsRequired();
		}
	}
}
