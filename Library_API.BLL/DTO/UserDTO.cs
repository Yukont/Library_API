using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Username length can't exceed 50 characters")]
        [Required(ErrorMessage = "Author is required")]
        public string Username { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Password length can't exceed 50 characters")]
        [Required(ErrorMessage = "Author is required")]
        public string Password { get; set; } = null!;
    }
}
