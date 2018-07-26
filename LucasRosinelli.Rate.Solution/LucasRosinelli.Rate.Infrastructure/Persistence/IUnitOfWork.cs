using System;

namespace LucasRosinelli.Rate.Infrastructure.Persistence
{
    /// <summary>
    /// Contract that ensures all repositories use the same context.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Method

        /// <summary>
        /// Confirms transactions.
        /// </summary>
        void Commit();

        #endregion
    }
}