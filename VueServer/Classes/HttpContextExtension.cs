using VueServer.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueServer.Classes
{
    public static class HttpContextExtension
    {
        public static async Task RefreshLoginAsync(this HttpContext context)
        {
            if (context.User == null)
                return;

            var userManager = context.RequestServices
                .GetRequiredService<UserManager<ServerIdentity>>();
            var signInManager = context.RequestServices
                .GetRequiredService<SignInManager<ServerIdentity>>();

            ServerIdentity user = await userManager.GetUserAsync(context.User);

            if (signInManager.IsSignedIn(context.User))
            {
                await signInManager.RefreshSignInAsync(user);
            }
        }
    }
}
