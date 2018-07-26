using LucasRosinelli.Rate.Domain.Contracts.Repositories;
using LucasRosinelli.Rate.Domain.Entities;
using LucasRosinelli.Rate.Domain.Specifications;
using LucasRosinelli.Rate.Infrastructure.Persistence.DataContext;
using System.Linq;

namespace LucasRosinelli.Rate.Infrastructure.Repository
{
    public class ReferenceStatisticRepository : IReferenceStatisticRepository
    {
        private readonly IDataContext _dataContext;

        public ReferenceStatisticRepository(IDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

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