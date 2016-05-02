using App.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace App.Identity.Contexto
{
    public class AppIdentityContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public AppIdentityContext() : base("AppConnect", throwIfV1Schema: false)
        {

        }

        public static AppIdentityContext Create()
        {
            return new AppIdentityContext();
        }
    }
}
