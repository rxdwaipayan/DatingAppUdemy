using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTO
{
    public class UserForRegisterDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(8,MinimumLength =4, ErrorMessage ="Must be within 8 to 4 letters")]
        public string password { get; set; }
    }
}
