using LucasRosinelli.Rate.Domain.Scopes;
using LucasRosinelli.Rate.SharedKernel.Helpers;

namespace LucasRosinelli.Rate.Domain.Entities
{
    /// <summary>
    /// European statistics for currencies.
    /// </summary>
    public class ReferenceStatistic
    {
        #region Properties

        /// <summary>
        /// Currency.
        /// </summary>
        public string Currency { get; private set; }
        /// <summary>
        /// Euro reference rate.
        /// </summary>
        public decimal Rate { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new reference statistic.
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <param name="rate">Euro reference rate.</param>
        public ReferenceStatistic(string currency, decimal rate)
        {
            this.Currency = StringHelper.Clear(currency)?.ToUpper();
            this.Rate = rate;
        }

        #endregion

        #region Methods

        public bool Register()
        {
            return this.RegisterIsValid();
        }

        /// <summary>
        /// Gets a new rate based on other reference (not Euro).
        /// </summary>
        /// <param name="referenceStatistic">Reference statistic used as base to give a new rate to this currency.</param>
        /// <returns>Rate based on reference.</returns>
        public decimal CalculateRate(ReferenceStatistic referenceStatistic)
        {
            return (1M / referenceStatistic.Rate) * this.Rate;
        }

        #endregion
    }
}