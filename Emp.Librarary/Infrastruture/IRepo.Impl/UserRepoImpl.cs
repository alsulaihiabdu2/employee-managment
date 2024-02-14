using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Librarary.Application.Services.impl
{
   

    public class UserRepoImpl : IUserRepository
    {
        private List<User> _users = new List<User>
        {
            new User{ UserName = "Admin", Password = "Password"}
        };

        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
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
