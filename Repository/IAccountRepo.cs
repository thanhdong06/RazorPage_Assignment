using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepo
    {
        public StaffMember GetStaffAccount(int accountId);
        public List<StaffMember> GetStaffAccounts();
        public void AddStaffAccounts(StaffMember account);

        public void UpdateStaffAccounts(StaffMember account);
        public void RemoveStaffAccounts(int id);

        public StaffMember GetAccountByEmailandPassword(string email, string password);
    }
}
