using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Deleted { get; set; } = false;
    }
}
