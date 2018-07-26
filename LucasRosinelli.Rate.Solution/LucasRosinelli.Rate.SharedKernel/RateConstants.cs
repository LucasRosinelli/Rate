using System.Globalization;

namespace LucasRosinelli.Rate.SharedKernel
{
    /// <summary>
    /// Constants shared through solution.
    /// </summary>
    public class RateConstants
    {
        #region Assertions

        /// <summary>
        /// Assertion argument length.
        /// </summary>
        public const string AssertArgumentLength = "AssertArgumentLength";
        /// <summary>
        /// Assertion argument matches.
        /// </summary>
        public const string AssertArgumentMatches = "AssertArgumentMatches";
        /// <summary>
        /// Assertion argument not empty.
        /// </summary>
        public const string AssertArgumentNotEmpty = "AssertArgumentNotEmpty";
        /// <summary>
        /// Assertion argument not null.
        /// </summary>
        public const string AssertArgumentNotNull = "AssertArgumentNotNull";
        /// <summary>
        /// Assertion argument true.
        /// </summary>
        public const string AssertArgumentTrue = "AssertArgumentTrue";
        /// <summary>
        /// Assertion argument false.
        /// </summary>
        public const string AssertArgumentFalse = "AssertArgumentFalse";
        /// <summary>
        /// Assertion argument are equals.
        /// </summary>
        public const string AssertArgumentAreEquals = "AssertArgumentAreEquals";
        /// <summary>
        /// Assertion argument is greater than.
        /// </summary>
        public const string AssertArgumentIsGreaterThan = "AssertArgumentIsGreaterThan";
        /// <summary>
        /// Assertion argument is greater or equal than.
        /// </summary>
        public const string AssertArgumentIsGreaterOrEqualThan = "AssertArgumentIsGreaterOrEqualThan";
        /// <summary>
        /// Assertion argument between.
        /// </summary>
        public const string AssertArgumentBetween = "AssertArgumentBetween";
        /// <summary>
        /// Assertion data context load fail.
        /// </summary>
        public const string AssertDataContextLoadFail = "AssertDataContextLoadFail";

        #endregion

        #region Messages

        /// <summary>
        /// Message not identified.
        /// </summary>
        public const int MessageNotIdentified = -1;

        #endregion

        #region Util

        /// <summary>
        /// Culture name: English (en).
        /// </summary>
        public const string CultureInfoNameEnglish = "en";
        /// <summary>
        /// Culture information: English (en).
        /// </summary>
        public static readonly CultureInfo CultureInfoEnglish;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes culture.
        /// </summary>
        static RateConstants()
        {
            CultureInfoEnglish = new CultureInfo(RateConstants.CultureInfoNameEnglish);
        }

        #endregion
    }
}