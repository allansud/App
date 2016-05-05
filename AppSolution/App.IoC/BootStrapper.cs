using App.Business.Implementation;
using App.Business.Interface;
using App.Identity.Configuration;
using App.Identity.Contexto;
using App.Identity.Model;
using App.Identity.Stores;
using App.Repository.Contexto;
using App.Repository.Implementation;
using App.Repository.Interface;
using App.Repository.UnitOfWork;
using Microsoft.AspNet.Identity;
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
            container.Register(() => new CustomUserStore(new AppIdentityContext()), Lifestyle.Scoped);
            container.Register(() => new CustomRoleStore(new AppIdentityContext()), Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<AppUser, int>>(() => container.GetInstance<CustomUserStore>());
            container.RegisterPerWebRequest<IRoleStore<AppRole, int>>(() => container.GetInstance<CustomRoleStore>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();            
        }
    }
}
