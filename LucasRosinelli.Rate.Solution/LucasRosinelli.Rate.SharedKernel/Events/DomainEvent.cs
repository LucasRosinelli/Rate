using LucasRosinelli.Rate.SharedKernel.Contracts;

namespace LucasRosinelli.Rate.SharedKernel.Events
{
    /// <summary>
    /// Domain event.
    /// </summary>
    public static class DomainEvent
    {
        #region Property

        /// <summary>
        /// services container.
        /// </summary>
        public static IContainer Container { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// Raise service to handle.
        /// </summary>
        /// <typeparam name="T">Type of the service.</typeparam>
        /// <param name="args">Arguments to handle.</param>
        public static void Raise<T>(T args)
            where T : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(IHandler<T>));
                    ((IHandler<T>)obj).Handle(args);
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}