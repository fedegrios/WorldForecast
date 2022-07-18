using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Interfaces;
using Interfaces.Dtos;
using Services.Mapper;
using Repositories;

namespace Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthServices(UnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Response<string>> LoginUser(UserLoginDto dto)
        {
            try
            {
                string[] errMgs = new string[1];
                var user = await _unitOfWork.AuthRepository.GetByEmailAsync(dto.Email);
                var passHash = GetHash(dto.Password);

                if (user == null || user.Password != passHash)
                { 
                    errMgs[0] = "Usuario o contraseña incorrecta.";
                    return new Response<string>(string.Empty, ResponseType.NotFound, errMgs);
                }
                
                return new Response<string>(GenerateToken(user.Email), ResponseType.Success, errMgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@$"LoginUser: {ex.Message}");

                string[] errMgs = new string[1];
                errMgs[0] = "Error insesperado.";

                return new Response<string>(string.Empty, ResponseType.Unexpected, errMgs);
            }
        }

        public async Task<Response<string>> RegisterUser(UserRegisterDto dto)
        {
            try
            {
                string[] errMgs = new string[1];
                var user = await _unitOfWork.AuthRepository.GetByEmailAsync(dto.Email);

                if (user != null)
                {
                    errMgs[0] = "Usuario ya se encuentra registrado.";
                    return new Response<string>(string.Empty, ResponseType.ValidationErr, errMgs);
                }

                user = dto.MapToUser();
                user.Password = GetHash(dto.Password);

                var lstMatch = await _unitOfWork.MatchRepository.ListAsync();

                foreach (var match in lstMatch)
                    user.Predictions.Add(new() {
                        MatchId = match.Id,
                        LocalScore = 0,
                        VisitScore = 0,
                        Points = 0
                    });

                await _unitOfWork.AuthRepository.RegisterAsync(user);

                await _unitOfWork.SaveChanges();

                return new Response<string>(GenerateToken(user.Email), ResponseType.Success, errMgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@$"RegisterUser: {ex.Message}");

                string[] errMgs = new string[1];
                errMgs[0] = "Error insesperado.";

                return new Response<string>(string.Empty, ResponseType.Unexpected, errMgs);
            }
        }

        private string GenerateToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT").GetSection("Secret").Value
                ));

            ClaimsIdentity claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(type: "email", value: email));

            var tokenDescriptor = new SecurityTokenDescriptor
            { 
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }

        private string GetHash(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            using var sha = new System.Security.Cryptography.SHA256Managed();
            byte[] textBytes = Encoding.UTF8.GetBytes(str);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            string hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", string.Empty);

            return hash;
        }
    }
}
