using Microsoft.AspNetCore.Identity;

namespace PCBuilder.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}