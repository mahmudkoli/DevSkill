using System;

using Microsoft.AspNetCore.Identity;

namespace DevSkill.Membership.Entities
{
    public class ApplicationUserToken
        : IdentityUserToken<Guid>
    {
        public ApplicationUserToken()
            : base()
        {

        }
    }
}
