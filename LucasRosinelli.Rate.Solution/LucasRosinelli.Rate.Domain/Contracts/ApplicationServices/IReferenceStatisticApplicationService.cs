using LucasRosinelli.Rate.Domain.Entities;

namespace LucasRosinelli.Rate.Domain.Contracts.ApplicationServices
{
    /// <summary>
    /// Contract related to reference statistics business intelligence.
    /// </summary>
    public interface IReferenceStatisticApplicationService
    {
        #region Methods

        /// <summary>
        /// Gets the rate of a currency pair.
        /// </summary>
        /// <param name="currencyPair">Currency pair.</param>
        /// <returns>Rate.</returns>
        decimal GetRate(string currencyPair);
        /// <summary>
        /// Gets a reference statistic by currency.
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <returns>Reference statistic if found; otherwise null.</returns>
        ReferenceStatistic GetByCurrency(string currency);

        #endregion
    }
}