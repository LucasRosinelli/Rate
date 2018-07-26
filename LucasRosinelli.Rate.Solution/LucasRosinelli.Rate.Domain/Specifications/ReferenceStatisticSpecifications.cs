using LucasRosinelli.Rate.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace LucasRosinelli.Rate.Domain.Specifications
{
    /// <summary>
    /// Lambda expressions related to reference statistic.
    /// </summary>
    public static class ReferenceStatisticSpecifications
    {
        #region Method

        /// <summary>
        /// Gets reference statistic by currency.
        /// </summary>
        /// <param name="currency">Currency to find.</param>
        /// <returns>Matching reference statistic.</returns>
        public static Expression<Func<ReferenceStatistic, bool>> GetByCurrency(string currency)
        {
            currency = currency?.ToUpper();
            return x => x.Currency == currency;
        }

        #endregion
    }
}