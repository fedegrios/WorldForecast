using Dominio.Entities;

namespace Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> GetByEmailAsync(string email);

        Task RegisterAsync(User user);
    }
}
