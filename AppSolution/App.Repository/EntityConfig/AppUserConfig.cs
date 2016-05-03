using App.Identity.Model;
using System.Data.Entity.ModelConfiguration;

namespace App.Repository.EntityConfig
{
    public class AppUserConfig : EntityTypeConfiguration<AppUser>
    {
        public AppUserConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetUsers");
        }
    }
}
