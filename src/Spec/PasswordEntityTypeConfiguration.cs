using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal class PasswordEntityTypeConfiguration : EntityTypeConfiguration<Password>
    {
        public PasswordEntityTypeConfiguration()
        {
            ToTable("passwords");

            HasKey(x => new { x.Md5, x.UId });

            Property(x => x.UId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
