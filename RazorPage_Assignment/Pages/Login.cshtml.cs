using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service;
using System.Security.Principal;

namespace RazorPage_Assignment.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAuthenticateUser _authenticateUser;
        public LoginModel(IAuthenticateUser authenticateUser)
        {
            _authenticateUser = authenticateUser;
        }

        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            StaffMember check = _authenticateUser.GetAccountByEmailAndPassword(email, password);
            if (check == null)
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            }
            else if (check.Role == 1)
            {
                HttpContext.Session.SetInt32("Role", (int)check.Role);
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(check));
                StaffMember acount = JsonConvert.DeserializeObject<StaffMember>(HttpContext.Session.GetString("Account"));
                return RedirectToPage("/Accounts/Index");            
            }
            else if (check.Role == 0)
            {
                HttpContext.Session.SetInt32("Role", (int)check.Role);
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(check));
                ViewData["notification"] = "You do not have permission to do this function!";
            }
            return Page();
        }
    }
}
