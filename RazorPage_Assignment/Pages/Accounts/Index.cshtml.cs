using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BO;
using Repository;

namespace RazorPage_Assignment.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepo _accountRepo = null;

        public IndexModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public IList<StaffMember> StaffMember { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_accountRepo.GetStaffAccounts() != null)
            //{
            //    StaffMember =  _accountRepo.GetStaffAccounts();
            //}
            StaffMember = _accountRepo.GetStaffAccounts();
        }
    }
}
