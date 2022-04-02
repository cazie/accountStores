
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razortests.Data;
using razortests.Models;

namespace razortests.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountModel Account { get; set; }

        public void OnGet(int id)
        {
            Account = _context.Accounts.Find(id);
          // Account = _context.Accounts.First(a => a.Id == id); // if not find first gets error
            //Account = _context.Accounts.FirstOrDefault(a => a.Id == id); // return null if not find
            //Account = _context.Accounts.Single(a => a.Id == id); // expect 1 only
            //Account = _context.Accounts.SingleOrDefault(a => a.Id == id); // return null if not find
        }

        //   public async Task<IActionResult> OnPost(AccountModel account) only if not [binding property] [bindproperites] at top of class for all properites

        public async Task<IActionResult> OnPost()
        {
            //no reps
            if (Account.AccountName == Account.DisplayOrder.ToString())
            {
                //ModelState.AddModelError(string.Empty, "Display order cannot match name"); //   <div asp-validation-summary="All"></div>
                ModelState.AddModelError(Account.AccountName, "Display order cannot match name");
            }

            if (ModelState.IsValid == false)
            {
                return Page();
            }

            _context.Update(Account);
            await _context.SaveChangesAsync();
            TempData["success"] = "Account Updated Successfully";
           
            return RedirectToPage("Index");
        }

    }
}
