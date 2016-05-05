using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace App.Identity.Model
{
    public class AppRole : IdentityRole<int, AppUserRole>
    {
        public AppRole()
        {
           
        }
        //public int Id { get; set; }

        //public string Name { get; set; }

        //public virtual ICollection<AppUser> Users { get; set; }
    }
}
