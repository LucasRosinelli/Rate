using LucasRosinelli.Rate.Domain.Entities;

namespace LucasRosinelli.Rate.Domain.Contracts.ApplicationServices
{
    /// <summary>
    /// Contract related to reference statistics business intelligence.
    /// </summary>
    public interface IReferenceStatisticApplicationService
    {
        /// <summary>
        /// Gets a reference statistic by currency.
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <returns>Reference statistic if found; otherwise null.</returns>
        ReferenceStatistic GetByCurrency(string currency);
    }
}