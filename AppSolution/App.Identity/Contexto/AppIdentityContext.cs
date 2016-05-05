using App.Identity.Model;
using App.Identity.Stores;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace App.Identity.Contexto
{
    public class AppIdentityContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AppIdentityContext() : base("AppConnect")
        {

        }

        public static AppIdentityContext Create()
        {
            return new AppIdentityContext();
        }
    }
}
