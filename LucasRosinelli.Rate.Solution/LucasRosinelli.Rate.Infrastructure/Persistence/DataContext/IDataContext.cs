using LucasRosinelli.Rate.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LucasRosinelli.Rate.Infrastructure.Persistence.DataContext
{
    /// <summary>
    /// Contract to define data contexts.
    /// </summary>
    public interface IDataContext : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets if data was successfully loaded or not.
        /// </summary>
        bool IsLoaded { get; }
        /// <summary>
        /// Gets if data is expired or not.
        /// </summary>
        bool IsExpired { get; }
        /// <summary>
        /// Gets reference statistics data.
        /// </summary>
        ICollection<ReferenceStatistic> ReferenceStatistics { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Loads data from source.
        /// </summary>
        void Load();
        /// <summary>
        /// Saves changes.
        /// </summary>
        /// <returns>Records affected.</returns>
        int SaveChanges();

        #endregion
    }
}