using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Spec
{
    internal class UserEntityTypeConfiguration  : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityTypeConfiguration()
        {
            ToTable("users");

            HasKey(x => x.UserId);

            HasRequired(x => x.Username).WithMany().HasForeignKey(x => x.Md5);

            Property(x => x.Md5)
                .HasColumnName("md5")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Since)
                .HasColumnName("since");

            Property(x => x.UserId)
                .HasColumnName("entity_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
