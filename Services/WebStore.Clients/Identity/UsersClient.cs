using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services.Identity;

namespace WebStore.Clients.Identity
{
    public class UsersClient : BaseClient, IUsersClient
    {
        public UsersClient(IConfiguration Configuration) : base(Configuration, WebAPI.Identity.Users) { }
       
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken) { throw new System.NotImplementedException(); }
    }
}
