using System.ComponentModel.DataAnnotations;

namespace Interfaces.Dtos
{
    public class UserDetailDto : Dto
    {
        [Required]
        public string Name { get; set; }

        public List<PredictionDto> Predictions { get; set; }

    }

    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage ="Password no tiene el formato correcto.")]
        public string Password { get; set; }
    }

    public class UserRegisterDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage ="Password no tiene el formato correcto.")]
        public string Password { get; set; }
    }
}
