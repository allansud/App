using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Identity.Model
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUserRole() { }

        //
        // Summary:
        //     RoleId for the role
        public override int RoleId { get; set; }
        //
        // Summary:
        //     UserId for the user that is in the role
        public override int UserId { get; set; }
    }
}
