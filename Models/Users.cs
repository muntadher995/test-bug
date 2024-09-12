using Microsoft.AspNetCore.Identity;

namespace FinanceProject.Models
{
    public class Users : IdentityUser
    {
        public static implicit operator string?(Users? v)
        {
            throw new NotImplementedException();
        }
    }
}
