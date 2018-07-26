using System;

namespace LucasRosinelli.Rate.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}