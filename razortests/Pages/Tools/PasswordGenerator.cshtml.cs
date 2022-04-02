
using razortests.Pages.Accounts.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razortests.Models;

namespace GeneratePassword.Pages
{
    public class PasswordGeneratorModel : PageModel
    {
        private readonly GeneratorHelper _passwordGenHelper;

        public PasswordGeneratorModel(GeneratorHelper passwordGenHelper)
        {
            _passwordGenHelper = passwordGenHelper;
        }

        [BindProperty(SupportsGet = true)]
        public PasswordGenModel Generator { get; set; }
       
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {

                return Page();
            }

            Generator.GeneratedPassword = _passwordGenHelper.GeneratePassword(Generator.MaxLength, Generator.UseCaps, Generator.UseSymb, Generator.UseNumbers);


            return Page();
        }
    }
}
