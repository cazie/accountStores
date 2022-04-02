using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razortests.Data;
using razortests.Models;
using razortests.Data;

namespace razortests.Pages.AccountsTemp
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AccountModel> AccountModel { get;set; }

        public async Task OnGetAsync()
        {
            AccountModel = await _context.Accounts.ToListAsync();
        }
    }
}
