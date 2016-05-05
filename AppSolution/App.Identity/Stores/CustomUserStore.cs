using App.Identity.Contexto;
using App.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace App.Identity.Stores
{
    public class CustomUserStore : UserStore<AppUser, CustomRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public CustomUserStore(AppIdentityContext context)
            : base(context)
        {

        }
    }
}
