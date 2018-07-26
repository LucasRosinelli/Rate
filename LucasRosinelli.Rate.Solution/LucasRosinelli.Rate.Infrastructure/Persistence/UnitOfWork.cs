using LucasRosinelli.Rate.Infrastructure.Persistence.DataContext;

namespace LucasRosinelli.Rate.Infrastructure.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDataContext _dataContext;

        public UnitOfWork(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Commit()
        {
            this._dataContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._dataContext != null)
                {
                    this._dataContext.Dispose();
                    this._dataContext = null;
                }
            }
        }
    }
}