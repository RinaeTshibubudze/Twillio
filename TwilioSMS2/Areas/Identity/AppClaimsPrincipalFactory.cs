using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TwilioSMS2.Models;

namespace TwilioSMS2.Areas.Identity
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            //            if (!string.IsNullOrWhiteSpace(user.Name))
            //            {
            //                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
            //                    new Claim(ClaimTypes.Name, user.Name)
            //                });
            //            }

            return principal;
        }
    }
}
