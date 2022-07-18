using Interfaces.Dtos;

namespace Interfaces
{
    public interface IAuthServices
    {
        Task<Response<string>> RegisterUser(UserRegisterDto dto);

        Task<Response<string>> LoginUser(UserLoginDto dto);
    }
}
