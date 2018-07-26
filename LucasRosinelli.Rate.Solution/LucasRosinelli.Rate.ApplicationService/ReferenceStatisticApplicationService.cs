using LucasRosinelli.Rate.Domain.Contracts.ApplicationServices;
using LucasRosinelli.Rate.Domain.Contracts.Repositories;
using LucasRosinelli.Rate.Domain.Entities;
using LucasRosinelli.Rate.Infrastructure.Persistence;
using LucasRosinelli.Rate.SharedKernel.Validation;

namespace LucasRosinelli.Rate.ApplicationService
{
    /// <summary>
    /// Reference statistics business intelligence.
    /// </summary>
    public class ReferenceStatisticApplicationService : ApplicationServiceBase, IReferenceStatisticApplicationService
    {
        #region Field

        /// <summary>
        /// Reference statistics data persistence.
        /// </summary>
        private readonly IReferenceStatisticRepository _repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes reference statistics business intelligence.
        /// </summary>
        /// <param name="repository">Reference statistics data persistence.</param>
        /// <param name="unitOfWork">Unit of work for transactions.</param>
        public ReferenceStatisticApplicationService(IReferenceStatisticRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the rate of a currency pair.
        /// </summary>
        /// <param name="currencyPair">Currency pair.</param>
        /// <returns>Rate.</returns>
        public decimal GetRate(string currencyPair)
        {
            if (AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertLength(currencyPair, 6, 6, "Pair must have 6 characters.")
                ))
            {
                var fromCurrency = currencyPair.Substring(0, 3);
                var toCurrency = currencyPair.Substring(3, 3);
                var from = this.GetByCurrency(fromCurrency);
                var to = this.GetByCurrency(toCurrency);

                if (AssertionConcern.IsSatisfiedBy(
                    AssertionConcern.AssertNotNull(from, string.Concat("Currency ", fromCurrency, " not found.")),
                    AssertionConcern.AssertNotNull(to, string.Concat("Currency ", toCurrency, " not found."))
                    ))
                {
                    if (this.Commit())
                    {
                        return from.CalculateRate(to);
                    }
                }
            }

            return 0M;
        }

        /// <summary>
        /// Gets a reference statistic by currency.
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <returns>Reference statistic if found; otherwise null.</returns>
        public ReferenceStatistic GetByCurrency(string currency)
        {
            return this._repository.GetByCurrency(currency);
        }

        #endregion
    }
}