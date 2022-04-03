
using razortests.Pages.Accounts.Helpers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razortests.Models;

namespace GeneratePassword.Pages
{
    public class PasswordGeneratorModel : PageModel
    {
        

        [BindProperty(SupportsGet = true)]
        public PasswordGenModel Generator { get; set; }
       
        public void OnGet()
        {
            Generator.MaxLength = 10;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {

                return Page();
            }

            Generator.GeneratedPassword = GeneratorHelper.GenerateComplexPassword(Generator.MaxLength, Generator.UseCaps, Generator.UseSymb, Generator.UseNumbers);


            return Page();
        }
    }
}
