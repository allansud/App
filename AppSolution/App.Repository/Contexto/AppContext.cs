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
        //public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<AppUserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AppUserConfig());
            modelBuilder.Configurations.Add(new AppRoleConfig());
            modelBuilder.Configurations.Add(new AppUserClaimConfig());
            modelBuilder.Configurations.Add(new AppUserLoginConfig());

            //modelBuilder.Entity<AppUser>()
            //    .HasMany<AppUserLogin>(l => l.Logins)
            //    .WithRequired(c => c.User)
            //    .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<AppUser>()
                .HasMany<AppUserClaim>(a => a.Claims)
                .WithRequired(c => c.User)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<AppRole>()
                .HasMany(r => r.Users)
                .WithMany(a => a.Roles)
                .Map(m => m.ToTable("AspNetUserRoles")
                .MapLeftKey("UserId")
                .MapRightKey("RoleId"));
        }
    }   
}
