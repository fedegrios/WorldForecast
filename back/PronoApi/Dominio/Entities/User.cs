using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities
{
    public class User :Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        public List<Prediction> Predictions { get; set; }
    }
}
