using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BO;
using Repository;

namespace RazorPage_Assignment.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;

        public EditModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _accountRepo.GetStaffAccount == null)
            {
                return NotFound();
            }

            var staffmember =   _accountRepo.GetStaffAccount((int) id);
            if (staffmember == null)
            {
                return NotFound();
            }
            StaffMember = staffmember;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }       
            try
            {
               _accountRepo.UpdateStaffAccounts(StaffMember);
            }
            catch (DbUpdateConcurrencyException)
            {              
                    throw;              
            }
            return RedirectToPage("./Index");
        }
    }
}
