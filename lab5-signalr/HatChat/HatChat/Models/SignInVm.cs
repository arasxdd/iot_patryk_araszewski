using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HatChat.Models
{
    public class SignInVm
    {
        [Required(ErrorMessage = "User name is required.")]
        [MinLength(3,ErrorMessage = "The username can't be shorter than 3.")]
        public string Username { get; set; }
    }
}
