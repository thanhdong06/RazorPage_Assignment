using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private readonly AirConditionerShop2023DBContext dBContext = null;

        public MemberDAO()
        {
            if (dBContext == null)
            {
                dBContext = new AirConditionerShop2023DBContext();
            }
        }
        public static MemberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }

        public StaffMember GetStaffAccount(int accountID)
        {
            return dBContext.StaffMembers.FirstOrDefault(m => m.MemberId.Equals(accountID));
        }
        public StaffMember GetAccountByEmailAndPassword(string email, string password)
        {
             return  dBContext.StaffMembers.SingleOrDefault(m => m.EmailAddress.Trim().Equals(email) && m.Password.Trim().Equals(password));
        }
        public List<StaffMember> GetStaffAccounts()
        {
            return dBContext.StaffMembers.ToList();
        }

        public void AddStaffAccount(StaffMember account)
        {
            StaffMember staff = GetStaffAccount(account.MemberId);
            if (staff == null)
            {
                dBContext.Add(account);
                dBContext.SaveChanges();
            }

        }

        public void UpdateStaffAccount(StaffMember account)
        {
            StaffMember staff = GetStaffAccount(account.MemberId);
            if (staff != null)
            {
                dBContext.Entry(account).State = EntityState.Modified;
                dBContext.Update(account);
                dBContext.SaveChanges();
            }
        }
        public void DeleteStaffAccount(int id)
        {
            StaffMember staff = GetStaffAccount(id);
            if (staff != null)
            {
                dBContext.Remove(staff);
                dBContext.SaveChanges();
            }

        }
    }


}
