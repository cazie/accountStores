using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razortests.Data;
using razortests.Models;

namespace razortests.Pages.AccountsTemp
{
    public class DetailsModel : PageModel
    {
        private readonly razortests.Data.ApplicationDbContext _context;

        public DetailsModel(razortests.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AccountModel AccountModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AccountModel = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);

            if (AccountModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
