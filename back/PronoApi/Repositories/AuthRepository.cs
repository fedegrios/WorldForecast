using Dominio.Entities;
using Infrastructure;
using Repositories.Interfaces;

namespace Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
            => _context.Set<User>().FirstOrDefault(u => u.Email == email);

        public async Task RegisterAsync(User user)
            => await _context.Set<User>().AddAsync(user);
    }
}
