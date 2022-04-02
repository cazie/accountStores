using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razortests.Data;
using razortests.Models;

namespace razortests.Pages.AccountsTemp
{
    public class CreateModel : PageModel
    {
        private readonly razortests.Data.ApplicationDbContext _context;

        public CreateModel(razortests.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AccountModel AccountModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(AccountModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
