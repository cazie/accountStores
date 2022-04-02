
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razortests.Data;
using razortests.Models;

namespace razortests.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AccountModel Account { get; set; }

        public void OnGet()
        {
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

            await _context.AddAsync(Account);
            await _context.SaveChangesAsync();
            TempData["success"]="Account Created Successfully";
            return RedirectToPage("Index");
        }

    }
}
