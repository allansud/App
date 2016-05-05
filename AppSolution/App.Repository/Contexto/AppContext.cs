using App.Identity.Model;
using App.Repository.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace App.Repository.Contexto
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppConnect") { }

        public DbSet<AppUser> Usuarios { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUserClaim> UserClaims { get; set; }        
        public DbSet<AppUserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Allan");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Configurations.Add(new AppUserConfig());
            //modelBuilder.Configurations.Add(new AppRoleConfig());
            //modelBuilder.Configurations.Add(new AppUserClaimConfig());
            //modelBuilder.Configurations.Add(new AppUserLoginConfig());

            //Mapeando AppUserLogin...
            modelBuilder.Entity<AppUserLogin>().Map(c => 
            {
                c.ToTable("UserLogin");
                c.Properties(p => new
                {
                    p.UserId,
                    p.LoginProvider,
                    p.ProviderKey
                });
            }).HasKey(p => new { p.ProviderKey, p.LoginProvider, p.UserId});

            //Mapeando a parte de Roles...
            modelBuilder.Entity<AppRole>().Map(r => 
            {
                r.ToTable("Role");
                r.Property(p => p.Id).HasColumnName("RoleId");
                r.Properties(p => new
                {
                    p.Name
                });
            }).HasKey(p => p.Id);

            //Relacionamentos AppRole
            modelBuilder.Entity<AppRole>().HasMany(c => c.Users).WithRequired().HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<AppUser>().Map(m => 
            {
                m.ToTable("User");
                m.Properties(p => new
                {
                    p.AccessFailedCount,
                    p.Email,
                    p.EmailConfirmed,
                    p.PasswordHash,
                    p.PhoneNumber,
                    p.PhoneNumberConfirmed,
                    p.TwoFactorEnabled,
                    p.SecurityStamp,
                    p.LockoutEnabled,
                    p.LockoutEndDateUtc,
                    p.UserName
                });
            }).HasKey(c => c.Id);

            //Relacionamentos AppUser...
            modelBuilder.Entity<AppUser>().HasMany(c => c.Logins).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<AppUser>().HasMany(c => c.Claims).WithOptional().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<AppUser>().HasMany(c => c.Roles).WithRequired().HasForeignKey(c => c.UserId);

            //Mapeando AppUserRole...
            modelBuilder.Entity<AppUserRole>().Map(m => 
            {
                m.ToTable("UserRole");
                m.Properties(p => new
                {
                    p.UserId,
                    p.RoleId
                });
            }).HasKey(c => new { c.UserId, c.RoleId });

            //Mapeando AppUserClaim
            modelBuilder.Entity<AppUserClaim>().Map(c => 
            {
                c.ToTable("UserClaim");
                c.Properties(p => new
                {
                    p.UserId,
                    p.ClaimValue,
                    p.ClaimType
                });
            }).HasKey(c => c.Id);
        }
    }   
}
