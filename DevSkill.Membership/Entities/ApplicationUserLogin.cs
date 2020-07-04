using System;

using Microsoft.AspNetCore.Identity;

namespace DevSkill.Membership.Entities
{
    public class ApplicationUserLogin
        : IdentityUserLogin<Guid>
    {
        public ApplicationUserLogin()
            : base()
        {

        }
    }
}
