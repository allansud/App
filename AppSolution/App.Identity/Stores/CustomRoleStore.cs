using App.Identity.Contexto;
using App.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Identity.Stores
{
    public class CustomRoleStore : RoleStore<AppRole, int, AppUserRole>
    {
        public CustomRoleStore(AppIdentityContext context) : base(context)
        {

        }
    }
}
