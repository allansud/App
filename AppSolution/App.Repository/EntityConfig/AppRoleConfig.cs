using App.Identity.Model;
using System.Data.Entity.ModelConfiguration;

namespace App.Repository.EntityConfig
{
    public class AppRoleConfig : EntityTypeConfiguration<AppRole>
    {
        public AppRoleConfig()
        {
            Property(r => r.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
