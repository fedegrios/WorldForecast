using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities
{
    public class Match :Entity
    {
        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [Required]
        public int LocalId { get; set; }

        [Required]
        public int VisitId { get; set; }

        [Required]
        [Range(0, 9)]
        public int LocalScore { get; set; }

        [Required]
        [Range(0, 9)]
        public int VisitScore { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Team Local { get; set; }

        public Team Visit { get; set; }
    }
}
