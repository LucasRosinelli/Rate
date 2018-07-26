using LucasRosinelli.Rate.Domain.Entities;

namespace LucasRosinelli.Rate.Domain.Scopes
{
    public static class ReferenceStatisticScopes
    {
        public static bool RegisterIsValid(this ReferenceStatistic referenceStatistic)
        {
            return false;
        }
    }
}