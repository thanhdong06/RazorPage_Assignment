using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAuthenticateUser
    {
        public StaffMember GetAccountByEmailAndPassword(string email, string password);
    }
}
