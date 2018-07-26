using LucasRosinelli.Rate.Infrastructure.Persistence.DataContext;

namespace LucasRosinelli.Rate.Infrastructure.Persistence
{
    /// <summary>
    /// Contract that ensures all repositories use the same context.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Field

        /// <summary>
        /// Data context used for data persistence.
        /// </summary>
        private IDataContext _dataContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes unit of work.
        /// </summary>
        /// <param name="dataContext">Data context used for data persistence.</param>
        public UnitOfWork(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        #endregion

        #region IUnitOfWork implementation

        /// <summary>
        /// Confirms transactions.
        /// </summary>
        public void Commit()
        {
            this._dataContext.SaveChanges();
        }

        /// <summary>
        /// Disposes object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion

        #region Method

        /// <summary>
        /// Disposes object.
        /// </summary>
        /// <param name="disposing">true to dispose objects.</param>
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

        #endregion
    }
}