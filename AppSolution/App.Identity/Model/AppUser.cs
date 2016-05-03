using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Identity.Model
{
    public class AppUser : IUser<int>
    {
        public AppUser()
        {
            Claims = new HashSet<AppUserClaim>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual bool TwoFactorEnabled { get; set; }

        public virtual DateTime? LockoutEndDateUtc { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }

        public virtual ICollection<AppUserClaim> Claims { get; set; }

        public virtual ICollection<AppRole> Roles { get; set; }

        public virtual ICollection<AppUserLogin> Logins { get; set; }
    }
}
