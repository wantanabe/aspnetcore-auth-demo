using Microsoft.AspNetCore.Identity;
using AuthDemo.Application.Dtos.Authentication;
using AuthDemo.Domain.Entities.Authentication;
using System.Threading.Tasks;

namespace AuthDemo.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<User> GetUserIdentityAsync(LoginRequest request);

        Task<IdentityResult> CreateUserIdentityAsync(RegisterRequest request);

        Task<UserResponse> GetUserProfileAsync(string userName);

        Task<string> BuildTokenAsync(User user);
    }
}
