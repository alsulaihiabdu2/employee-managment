using Emp.Librarary.Application.IServices;
using Emp.Librarary.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Librarary.Infrastruture.IRepo.Impl
{
    

    public class UserRepositoryImpl : IUserRepository
    {
        private List<User> _users = new List<User>
        {
            new User{ UserName = "Admin", Password = "123"}
        };

        private readonly IConfiguration _configuration;

        public UserRepositoryImpl(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(User user)
        {
            var LoginUser = _users.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (LoginUser == null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }

}
