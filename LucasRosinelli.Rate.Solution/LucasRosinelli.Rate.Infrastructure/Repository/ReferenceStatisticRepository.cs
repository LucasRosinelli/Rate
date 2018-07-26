using LucasRosinelli.Rate.Domain.Contracts.Repositories;
using LucasRosinelli.Rate.Domain.Entities;
using LucasRosinelli.Rate.Domain.Specifications;
using LucasRosinelli.Rate.Infrastructure.Persistence.DataContext;
using System.Linq;

namespace LucasRosinelli.Rate.Infrastructure.Repository
{
    /// <summary>
    /// Reference statistics data persistence.
    /// </summary>
    public class ReferenceStatisticRepository : IReferenceStatisticRepository
    {
        #region Field

        /// <summary>
        /// Data context used for data persistence.
        /// </summary>
        private readonly IDataContext _dataContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes reference statistics data persistence.
        /// </summary>
        /// <param name="dataContext">Data context used for data persistence.</param>
        public ReferenceStatisticRepository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        #endregion

        #region IReferenceStatisticRepository implementation

        /// <summary>
        /// Gets a reference statistic by currency.
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <returns>Reference statistic if found; otherwise null.</returns>
        public ReferenceStatistic GetByCurrency(string currency)
        {
            return this._dataContext.ReferenceStatistics.FirstOrDefault(ReferenceStatisticSpecifications.GetByCurrency(currency).Compile());
        }

        #endregion
    }
}