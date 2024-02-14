using Emp.Librarary.Application.IServices;
using Emp.Librarary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Librarary.Application.Services.impl
{
    public class UserServiceImpl : IUserServices
    {
        readonly IUserRepository _userRepository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(User user)
        {
            return _userRepository.Login(user);
        }
    }
}
