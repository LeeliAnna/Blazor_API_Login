using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Forms
{
    public class UpdatePasswordForm
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmationPassword { get; set; }
    }
}
