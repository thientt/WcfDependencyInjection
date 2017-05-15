namespace Data.Core.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DIContext _context;

        public DIContext Init()
        {
            return _context ?? (_context = new DIContext());
        }

        protected override void DisposeCore()
        {
            base.DisposeCore();

            _context?.Dispose();
        }
    }
}