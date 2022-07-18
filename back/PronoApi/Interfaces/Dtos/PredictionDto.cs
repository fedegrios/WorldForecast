using System.ComponentModel.DataAnnotations;

namespace Interfaces.Dtos
{
    public class PredictionDto :Dto
    {
        [Required]
        [Url]
        public string MatchUrl { get; set; }

        [Required]
        public string Visit { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        [Range(0, 9)]
        public int LocalScore { get; set; }

        [Required]
        [Range(0, 9)]
        public int VisitScore { get; set; }

        [Required]
        [Range(0, 5)]
        public int Points { get; set; }

    }
}
