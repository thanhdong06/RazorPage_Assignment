using BO;
using Repository;
using System.Security.Principal;

namespace Service
{
    public class AuthenticateUser : IAuthenticateUser
    {
        private readonly IAccountRepo _accountRepo;

        public AuthenticateUser(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public StaffMember GetAccountByEmailAndPassword(string email, string password) => _accountRepo.GetAccountByEmailandPassword(email, password);

    }
}