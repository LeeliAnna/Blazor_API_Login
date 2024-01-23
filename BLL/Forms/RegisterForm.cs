using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Forms
{
    public class RegisterForm
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmationPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string Pseudo { get; set; }
    }
}
