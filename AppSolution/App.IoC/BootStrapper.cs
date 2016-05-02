using App.Business.Implementation;
using App.Business.Interface;
using App.Identity.Configuration;
using App.Identity.Contexto;
using App.Identity.Model;
using App.Repository.Contexto;
using App.Repository.Implementation;
using App.Repository.Interface;
using App.Repository.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace App.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<AppContext>();
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUsuarioBusiness, UsuarioBusiness>();

            //Asp.Net.Identity
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(container.GetInstance<AppContext>()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();            
        }
    }
}
