using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BO;
using Repository;

namespace RazorPage_Assignment.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;

        public CreateModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffMember StaffMember { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _accountRepo.GetStaffAccounts == null || StaffMember == null)
            {
                return Page();
            }

            _accountRepo.AddStaffAccounts(StaffMember);

            return RedirectToPage("./Index");
        }
    }
}
