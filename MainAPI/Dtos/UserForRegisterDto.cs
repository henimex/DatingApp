using System.ComponentModel.DataAnnotations;

namespace MainAPI.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Min 4 Max 8 Chars")]
        public string Password { get; set; }
    }
}
