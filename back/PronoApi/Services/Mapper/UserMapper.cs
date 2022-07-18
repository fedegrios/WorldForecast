using Dominio.Entities;
using Interfaces.Dtos;

namespace Services.Mapper
{
    public static class UserMapper
    {
        public static User MapToUser(this UserRegisterDto dto)
            => new() { 
                Deleted = false,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Predictions = new()
            };

        public static UserDetailDto MapToUserDetailDto(this User ent)
        { 
            UserDetailDto userDetailDto = new() {
                Id = ent.Id,
                Name = ent.Name,
                Predictions = new()
            };

            if (ent.Predictions != null && ent.Predictions.Count > 0)
                userDetailDto.Predictions = ent.Predictions
                    .Select(p => new PredictionDto { 
                        MatchUrl = "",
                        Local = p.Match.Local.Name,
                        Visit = p.Match.Visit.Name,
                        LocalScore = p.LocalScore,
                        VisitScore = p.VisitScore,
                        Points = p.Points
                    })
                    .ToList();

            return userDetailDto;
        }
    }
}
