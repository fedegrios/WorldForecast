using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities
{
    public class Prediction :Entity
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0, 9)]
        public int LocalScore { get; set; }

        [Required]
        [Range(0, 9)]
        public int VisitScore { get; set; }

        [Required]
        [Range(0, 5)]
        public int Points { get; set; }

        public Match Match { get; set; }

        public User User { get; set; }
    }
}
