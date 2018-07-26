using System;

namespace LucasRosinelli.Rate.SharedKernel.Contracts
{
    /// <summary>
    /// Domain event contract.
    /// </summary>
    public interface IDomainEvent
    {
        #region Property

        /// <summary>
        /// Date and time when event occurred.
        /// </summary>
        DateTime DateOccurred { get; }

        #endregion
    }
}