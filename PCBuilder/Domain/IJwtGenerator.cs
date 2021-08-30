using System.Collections.Generic;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IJwtGenerator
    {
        string CreateToken(ApplicationUser user, List<string> roles);
    }
}