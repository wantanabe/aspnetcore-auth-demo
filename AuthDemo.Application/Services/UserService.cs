using AutoMapper;
using AuthDemo.Application.Dtos.Authentication;
using AuthDemo.Application.Interfaces;
using AuthDemo.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<UserResponse>> GetUsersAsync()
        {
            var users = await _unitOfWork.Users.ListAsync(u => true);

            return _mapper.Map<IList<UserResponse>>(users);
        }
    }
}
