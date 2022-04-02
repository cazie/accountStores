using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razortests.Data;
using razortests.Models;

namespace razortests.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AccountModel> Accounts { get; set; }
        public void OnGet()
        {
            Accounts = _context.Accounts;
        }
    }
}
