using AuthDemo.Application.Dtos.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemo.Application.Interfaces
{
    public interface IUserService
    {
        Task<IList<UserResponse>> GetUsersAsync();
    }
}
