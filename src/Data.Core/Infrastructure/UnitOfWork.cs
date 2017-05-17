using System.Threading.Tasks;

namespace Data.Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private DIContext _context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _context = dbFactory.Init();
        }

        public DIContext Context => _context ?? (_context = _dbFactory.Init());

        public void Commit()
        {
            _context.Commit();
        }

        public Task CommitAsync()
        {
            return _context.CommitAsync();
        }

        public int Push()
        {
            return _context.Push();
        }

        public Task<int> PushAsync()
        {
            return _context.PushAsync();
        }
    }
}