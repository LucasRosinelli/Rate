using LucasRosinelli.Rate.SharedKernel.Contracts;

namespace LucasRosinelli.Rate.SharedKernel.Events
{
    /// <summary>
    /// Domain event.
    /// </summary>
    public static class DomainEvent
    {
        #region Properties

        public static IContainer Container { get; set; }

        #endregion

        #region Methods

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