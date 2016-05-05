using App.Identity.Contexto;
using App.Identity.Model;
using App.Identity.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace App.Identity.Configuration
{
    public class ApplicationRoleManager : RoleManager<AppRole, int>
    {
        public ApplicationRoleManager(IRoleStore<AppRole, int> roleStore)
            : base(roleStore)
        {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var customRoleStore = new CustomRoleStore(context.Get<AppIdentityContext>());
            return new ApplicationRoleManager(customRoleStore);
        }
    }
}
