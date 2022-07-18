using Interfaces.Dtos;

namespace Interfaces
{
    public interface IUserServices
    {
        Task<Response<UserDetailDto>> GetUserDetail(int id);
    }
}
