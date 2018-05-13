using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Project.Hub.Services
{
    /// <summary>
    /// It's very hardcoded user store just for admin user.
    /// Someday I will implement normal auth flow, but I'm very lazy now...
    /// </summary>
    public class VeryVeryHardcodedUserStore : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>
    {
        private readonly IReadOnlyList<IdentityUser> _users;

        public VeryVeryHardcodedUserStore(IPasswordHasher<IdentityUser> hasher)
        {
            var username = "admin";
            var password = "admin123456";

            var admin = new IdentityUser
            {
                Id = "1",
                UserName = username,
                NormalizedUserName = username.ToUpper()
            };

            admin.PasswordHash = hasher.HashPassword(admin, password);

            _users = new List<IdentityUser> { admin };
        }

        public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (userId == null) throw new ArgumentNullException(nameof(userId));

            var user = _users.FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(user);
        }

        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            if (normalizedUserName == null) throw new ArgumentNullException(nameof(normalizedUserName));

            var user = _users.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName);
            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.NormalizedUserName = normalizedName ?? throw new ArgumentNullException(nameof(normalizedName));
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
