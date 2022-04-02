using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace razortests.Models
{
    public class AccountModel
    {

        public int Id { get; set; }

        [DisplayName("Account Name")]
        [Required]
        public string AccountName { get; set; }

        [DisplayName("Description")]
        [Required]
        public string  Description { get; set; }

        [Required]
        [DisplayName("Account Password")]
        public string Password { get; set; }

        public int DisplayOrder { get; set; }



    }
}
