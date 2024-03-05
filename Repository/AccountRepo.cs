using BO;
using DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepo : IAccountRepo
    {
        public void AddStaffAccounts(StaffMember account) => MemberDAO.Instance.AddStaffAccount(account);
        public StaffMember GetStaffAccount(int accountId) => MemberDAO.Instance.GetStaffAccount(accountId);

        public void UpdateStaffAccounts(StaffMember account) => MemberDAO.Instance.UpdateStaffAccount(account);

        public List<StaffMember> GetStaffAccounts() => MemberDAO.Instance.GetStaffAccounts();
        public void RemoveStaffAccounts(int id) => MemberDAO.Instance.DeleteStaffAccount(id);
        public StaffMember GetAccountByEmailandPassword(string email, string password) => MemberDAO.Instance.GetAccountByEmailAndPassword(email, password);
    }
}

