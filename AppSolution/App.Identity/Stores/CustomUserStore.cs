using App.Identity.Contexto;
using App.Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace App.Identity.Stores
{
    public class CustomUserStore : UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>, IUserStore<AppUser, int>, IDisposable
    {
        public CustomUserStore(AppIdentityContext context)
            : base(context)
        {

        }
    }
}
