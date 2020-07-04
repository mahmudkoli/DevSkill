using System;

using Microsoft.AspNetCore.Identity;

namespace DevSkill.Membership.Entities
{
    public class ApplicationUserClaim
        : IdentityUserClaim<Guid>
    {
        public ApplicationUserClaim()
            : base()
        {

        }
    }
}
