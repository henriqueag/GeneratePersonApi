using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratePersonApi.Entities
{
    public static class DistinctExtension
    {
        public static IEnumerable<TSource> Distinct<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, bool> metodoEquals,
        Func<TSource, int> metodoGetHashCode)
            => source.Distinct(
                GenericComparator<TSource>.Criar(
                    metodoEquals,
                    metodoGetHashCode)
                    );
    }
}