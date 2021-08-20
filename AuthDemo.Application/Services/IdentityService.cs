using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AuthDemo.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthDemo.Application.Dtos.Authentication;
using AuthDemo.Application.Interfaces;

namespace AuthDemo.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private const double EXPIRY_DURATION_MINUTES = 30;

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public IdentityService(
            UserManager<User> userManager,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<User> GetUserIdentityAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null & await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return user;
            }

            return null;
        }

        public async Task<IdentityResult> CreateUserIdentityAsync(RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);

            return await _userManager.CreateAsync(user, request.Password);
        }

        public async Task<UserResponse> GetUserProfileAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<string> BuildTokenAsync(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"].ToString()));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"].ToString(),
                audience: _configuration["Jwt:Audience"].ToString(),
                claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
