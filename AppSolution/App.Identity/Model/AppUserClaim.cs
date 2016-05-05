using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Identity.Model
{
    public class AppUserClaim : IdentityUserClaim<int>
    {
        public AppUserClaim() { }
    }
}
