using ArathsBaby.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace arathsbaby_web.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal();
            return Task.FromResult(new AuthenticationState(user));
        }

        public void UserLogin(string Email)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,Email)
            },"authentication");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void UserLogout()
        {
            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
