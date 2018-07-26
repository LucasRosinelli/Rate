using LucasRosinelli.Rate.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace LucasRosinelli.Rate.Domain.Specifications
{
    public static class ReferenceStatisticSpecifications
    {
        public static Expression<Func<ReferenceStatistic, bool>> GetByCurrency(string currency)
        {
            return x => x.Currency == currency;
        }
    }
}