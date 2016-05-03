using App.Identity.Model;
using System.Data.Entity.ModelConfiguration;

namespace App.Repository.EntityConfig
{
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            HasKey(r => r.Id);

            Property(r => r.Name)
                .HasMaxLength(256)
                .IsRequired();

            ToTable("AspNetRoles");
        }
    }
}
