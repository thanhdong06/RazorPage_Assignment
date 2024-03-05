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
    public class DetailsModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;

        public DetailsModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

      public StaffMember StaffMember { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _accountRepo.GetStaffAccounts == null)
            {
                return NotFound();
            }

            var staffmember = _accountRepo.GetStaffAccount(id);
            if (staffmember == null)
            {
                return NotFound();
            }
            else 
            {
                StaffMember = staffmember;
            }
            return Page();
        }
    }
}
