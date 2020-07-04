using System;

using Microsoft.AspNetCore.Identity;

namespace DevSkill.Membership.Entities
{
    public class ApplicationRoleClaim
        : IdentityRoleClaim<Guid>
    {
        public ApplicationRoleClaim()
            : base()
        {

        }
    }
}
