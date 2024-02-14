using Emp.Librarary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Librarary.Application.IServices
{
    public interface IUserRepository
    {
      public  string Login(User user);

    }
}
