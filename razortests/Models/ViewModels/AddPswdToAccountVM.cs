using razortests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountStoreApp.Models.ViewModels
{
    public class AddPswdToAccountVM
    {
        public string AccountName { get; set; }

        //[DisplayName("Description")]
        //[Required]
        public string Description { get; set; }

        //[Required]
        //[DisplayName("Account Password")]
        public string Password { get; set; }

        public int MaxLength { get; set; } = 15;

        public Strength IsStrong { get; set; }

        public string GeneratedPassword { get; set; }
        public bool UseCaps { get; set; }

        public bool UseSymb { get; set; }

        public bool UseNumbers { get; set; }
    }
}
