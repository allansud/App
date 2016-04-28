using App.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Identity.Contexto
{
    public class AppIdentityContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public AppIdentityContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AppIdentityContext Create()
        {
            return new AppIdentityContext();
        }
    }
}
