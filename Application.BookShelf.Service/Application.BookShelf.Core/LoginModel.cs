using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookShelf.Core
{
    public class LoginModel
    {
      
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Username must be less than 25 characters.")]
        public string Username { get; set; }

      
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 15 characters.")]
        public string Password { get; set; }

    }
}
