using CongestionTax.Core;

namespace CongestionTax.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CongestionTaxDbContext _context;
        public ITollRepository _tollRepository;
        public UnitOfWork(CongestionTaxDbContext context,
                          ITollRepository tollRepository)
        {
            _context = context;
            _tollRepository = tollRepository;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
