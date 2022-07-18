using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities
{
    public class Team :Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public char Group { get; set; }
    }
}
