using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace App.Identity.Model
{
    public class AppRole : IRole<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }
    }
}
