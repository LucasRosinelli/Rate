using LucasRosinelli.Rate.Domain.Entities;
using LucasRosinelli.Rate.SharedKernel.Validation;

namespace LucasRosinelli.Rate.Domain.Scopes
{
    /// <summary>
    /// Validation rules related to reference statistic.
    /// </summary>
    public static class ReferenceStatisticScopes
    {
        #region Method

        /// <summary>
        /// Asserts reference statistic is valid for creation.
        /// </summary>
        /// <param name="referenceStatistic">Reference statistic to validate.</param>
        /// <returns>true if is valid; otherwise, false.</returns>
        public static bool RegisterIsValid(this ReferenceStatistic referenceStatistic)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertLength(referenceStatistic.Currency, 3, 3, "Currency must have 3 caracters length."),
                AssertionConcern.AssertValueIsGreaterThanZero(referenceStatistic.Rate, "Rate must be greater than zero.")
            );
        }

        #endregion
    }
}