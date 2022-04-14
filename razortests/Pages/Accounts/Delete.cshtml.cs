
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AccountStore.Data;
using AccountStore.Models;

namespace AccountStore.Pages.Accounts
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var accountFromDb = _context.Accounts.Find(Account.Id);

            if (accountFromDb != null)
            {
                _context.Remove(accountFromDb);
                await _context.SaveChangesAsync();
                TempData["success"] = "Account Deleted Successfully"; // then put msg in index
                return RedirectToPage("Index");
            }
            return Page();
           
        }

    }
}
