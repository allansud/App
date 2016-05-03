namespace App.Identity.Model
{
    public class AppUserClaim 
    {
        public AppUserClaim() { }

        //
        // Summary:
        //     Claim type
        public virtual string ClaimType { get; set; }
        //
        // Summary:
        //     Claim value
        public virtual string ClaimValue { get; set; }
        //
        // Summary:
        //     Primary key
        public virtual int Id { get; set; }
        //
        // Summary:
        //     User Id for the user who owns this login
        public virtual int UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
