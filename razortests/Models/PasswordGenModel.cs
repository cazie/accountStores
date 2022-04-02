using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razortests.Models
{
    public class PasswordGenModel
    {

        public string Letters { get; set; }
        public string Numbers { get; set; }
        public string Symbols { get; set; }
        public int MaxLength { get; set; } = 10;

        public string GeneratedPassword { get; set; }

        public bool UseCaps { get; set; }

        public bool UseSymb { get; set; }

        public bool UseNumbers { get; set; }


    }
}
