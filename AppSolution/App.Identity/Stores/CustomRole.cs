using App.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Identity.Stores
{
    public class CustomRole : IdentityRole<int, AppUserRole>
    {

    }
}
