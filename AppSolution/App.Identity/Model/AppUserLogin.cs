using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Identity.Model
{
    public class AppUserLogin : IdentityUserLogin<int>
    {
        public AppUserLogin() { }

        //
        // Summary:
        //     The login provider for the login (i.e. facebook, google)
        public override string LoginProvider { get; set; }
        //
        // Summary:
        //     Key representing the login for the provider
        public override string ProviderKey { get; set; }
        //
        // Summary:
        //     User Id for the user who owns this login
        public override int UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
