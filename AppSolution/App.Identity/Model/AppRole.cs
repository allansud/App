using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace App.Identity.Model
{
    public class AppRole : IdentityRole<int, AppUserRole>
    {
        public AppRole() {  }
        public AppRole(string name) { Name = name; }
    }
}
