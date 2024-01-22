using CRUD.Common.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CRUD.App.Classes
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _claimsPrincipal = new(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(_claimsPrincipal)));
        }

        public async Task SetAuthInfo(UserRoleDto user)
        {
            if (user.RoleDefinition == null)
            {
                _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }
            else
            {
                _claimsPrincipal = new ClaimsPrincipal(GetClaimsIdentity(user));
            }

            await Task.FromResult(() => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync()));
        }

        private static ClaimsIdentity GetClaimsIdentity(UserRoleDto userData)
        {
            ClaimsIdentity identity = new(new Claim[]
            {
                new(ClaimTypes.Name, userData?.UserName ?? string.Empty)
            }, "AuthInfo");

            identity.AddClaim(new Claim(ClaimTypes.Role, userData?.RoleDefinition ?? "Unknown"));
            return identity;
        }
    }
}