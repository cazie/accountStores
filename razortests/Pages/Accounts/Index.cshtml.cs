using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountStore.Data;
using AccountStore.Models;
using AccountStore.Services.Interfaces;

namespace AccountStore.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
     

        public IndexModel(ApplicationDbContext context, IImageService imageService)
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
