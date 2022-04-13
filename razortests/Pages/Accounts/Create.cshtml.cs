
using System.Threading.Tasks;
using AccountStoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razortests.Data;
using razortests.Models;
using razortests.Pages.Accounts.Helpers;

namespace razortests.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public AccountModel Account { get; set; }

        [BindProperty(SupportsGet = true)]
        public PasswordGenModel Generator { get; set; }

        [BindProperty(SupportsGet = true)]
        public AddPswdToAccountVM AddPswd { get; set; }


        public void OnGet()
        {
            //Generator.MaxLength = 10;
            AddPswd.GeneratedPassword = GeneratorHelper.GeneratePassword(Generator.MaxLength, Generator.UseCaps, Generator.UseSymb, Generator.UseNumbers);
            Account.Password = AddPswd.GeneratedPassword;
        }


        public void OnGetGenPassword()
        {
           

            //Generator.MaxLength = 10;
            Generator.GeneratedPassword = GeneratorHelper.GeneratePassword(Generator.MaxLength, Generator.UseCaps, Generator.UseSymb, Generator.UseNumbers);
           // Account.Password = Generator.GeneratedPassword;



        }
        //   public async Task<IActionResult> OnPost(AccountModel account) only if not [binding property] [bindproperites] at top of class for all properites



        public async Task<IActionResult> OnPost()
        {


            //Generator.GeneratedPassword = GeneratorHelper.GeneratePassword(Generator.MaxLength, Generator.UseCaps, Generator.UseSymb, Generator.UseNumbers);
            //Account.Password = Generator.GeneratedPassword;


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
