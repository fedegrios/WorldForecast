using Interfaces;
using Interfaces.Dtos;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Mapper;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<UserDetailDto>> GetUserDetail(int id)
        {
            try
            {
                string[] errMgs = new string[1];
                var user = await _unitOfWork.DataContext.Users
                    .Include("Predictions")
                    .Include("Predictions.Match")
                    .Include("Predictions.Match.Visit")
                    .Include("Predictions.Match.Local")
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                {
                    errMgs[0] = "No se pudo encontrar el usuario.";
                    return new Response<UserDetailDto>(null, ResponseType.NotFound, errMgs);
                }

                var userDetail = user.MapToUserDetailDto();

                return new Response<UserDetailDto>( userDetail , ResponseType.Success, errMgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@$"GetUserDetail: {ex.Message}");

                string[] errMgs = new string[1];
                errMgs[0] = "Error insesperado.";

                return new Response<UserDetailDto>(null, ResponseType.Unexpected, errMgs);
            }
        }
    }
}
