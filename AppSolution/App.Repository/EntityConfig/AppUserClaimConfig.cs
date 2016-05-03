using App.Identity.Model;
using System.Data.Entity.ModelConfiguration;

namespace App.Repository.EntityConfig
{
    public class AppUserClaimConfig : EntityTypeConfiguration<AppUserClaim>
    {
        public AppUserClaimConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.ClaimValue)
                .IsMaxLength();

            Property(c => c.ClaimType)
                .IsMaxLength();

            ToTable("AspNetUserClaims");
        }        
    }
}
