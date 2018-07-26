using LucasRosinelli.Rate.Domain.Entities;

namespace LucasRosinelli.Rate.Domain.Contracts.Repositories
{
    /// <summary>
    /// Contract related to reference statistics data persistence.
    /// </summary>
    public interface IReferenceStatisticRepository
    {
        #region Method

        /// <summary>
        /// Gets a reference statistic by currency.
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <returns>Reference statistic if found; otherwise null.</returns>
        ReferenceStatistic GetByCurrency(string currency);

        #endregion
    }
}