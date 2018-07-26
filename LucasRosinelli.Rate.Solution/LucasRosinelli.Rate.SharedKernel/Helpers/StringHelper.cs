namespace LucasRosinelli.Rate.SharedKernel.Helpers
{
    /// <summary>
    /// Helper for strings.
    /// </summary>
    public static class StringHelper
    {
        #region Methods

        /// <summary>
        /// Clear all leading and trailing white-space caracters from content.
        /// </summary>
        /// <param name="content">Content to be cleared.</param>
        /// <returns>Cleared value. Null if value is null, empty, or consists only of white-space characters.</returns>
        public static string Clear(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            return content.Trim();
        }

        #endregion
    }
}