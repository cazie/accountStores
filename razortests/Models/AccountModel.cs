using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountStore.Models
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


        [DataType(DataType.Date)]
        public DateTime Created { get; set; }


        //image set up
        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }

    }
}
