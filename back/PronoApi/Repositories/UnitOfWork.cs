using Dominio.Entities;
using Infrastructure;
using Repositories.Interfaces;

namespace Repositories
{
    public class UnitOfWork
    {
        private readonly DataContext _dataContext;
        public DataContext DataContext => _dataContext;


        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SaveChanges()
            => await _dataContext.SaveChangesAsync();

        private IAuthRepository _authRepository;
        public IAuthRepository AuthRepository => _authRepository ??= new AuthRepository(_dataContext);

        private IRepository<User> _userRepository;
        public IRepository<User> UserRepository => _userRepository ??= new Repository<User>(_dataContext);

        private IRepository<Team> _teamRepository;
        public IRepository<Team> TeamRepository => _teamRepository ??= new Repository<Team>(_dataContext);

        private IRepository<Prediction> _predictionRepository;
        public IRepository<Prediction> PredictionRepository => _predictionRepository ??= new Repository<Prediction>(_dataContext);

        private IRepository<Match> _matchRepository;
        public IRepository<Match> MatchRepository => _matchRepository ??= new Repository<Match>(_dataContext);

    }
}
