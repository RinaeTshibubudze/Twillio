using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TwilioSMS2.Models;
using TwilioSMS2.Services;

namespace TwilioSMS2.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Verify")]
    public class VerifyApiController : Controller
    {

        private readonly IVerification _verification;
        private readonly UserManager<ApplicationUser> _userManager;

        public VerifyApiController(IVerification verification, UserManager<ApplicationUser> manager)
        {
            _verification = verification;
            _userManager = manager;
        }

        [HttpPost]
        public async Task<VerificationResult> Post(string channel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (!user.Verified)
            {
                return await _verification.StartVerificationAsync(user.PhoneNumber, channel);
            }

            return new VerificationResult(new List<string> { "Your phone number is already verified" });
        }
    }
}
