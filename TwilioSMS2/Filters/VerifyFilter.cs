using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TwilioSMS2.Models;


namespace TwilioSMS2.Filters
{
    public class VerifyFilter : IAsyncResourceFilter
    {

        private readonly UserManager<ApplicationUser> _manager;

        public VerifyFilter(UserManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity is {IsAuthenticated: false})
            {
                throw new Exception("Authentication required before verification");
            }

            var user = await _manager.GetUserAsync(context.HttpContext.User);
            if (!user.Verified)
            {
                context.Result = new RedirectResult("/Identity/Account/Verify");
            }
            else
            {
                await next();
            }
        }
    }
}
