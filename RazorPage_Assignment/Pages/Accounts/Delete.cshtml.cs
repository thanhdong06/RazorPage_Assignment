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
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;

        public DeleteModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [BindProperty]
      public StaffMember StaffMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _accountRepo.GetStaffAccounts == null)
            {
                return NotFound();
            }

            var staffmember =  _accountRepo.GetStaffAccount(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _accountRepo.GetStaffAccounts == null)
            {
                return NotFound();
            }
            var staffmember =  _accountRepo.GetStaffAccount(id);

            if (staffmember != null)
            {              
                _accountRepo.RemoveStaffAccounts(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
