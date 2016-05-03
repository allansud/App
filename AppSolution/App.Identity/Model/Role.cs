using Microsoft.AspNet.Identity;

namespace App.Identity.Model
{
    public class Role : IRole<int>
    {
        public int Id { get; }

        public string Name { get; set; }
    }
}
