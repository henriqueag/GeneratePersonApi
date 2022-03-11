using System;
using System.Collections.Generic;

namespace DocumentGenerator.Entities
{
    internal class GenericComparator<TSource> : IEqualityComparer<TSource>
    {
        public Func<TSource, TSource, bool> MetodoEquals { get; }
        public Func<TSource, int> MetodoGetHashCode { get; }

        private GenericComparator(
            Func<TSource, TSource, bool> metodoEquals,
            Func<TSource, int> metodoGetHashCode)
        {
            this.MetodoEquals = metodoEquals;
            this.MetodoGetHashCode = metodoGetHashCode;
        }

        public static GenericComparator<TSource> Criar(
            Func<TSource, TSource, bool> metodoEquals,
            Func<TSource, int> metodoGetHashCode)
                => new(
                        metodoEquals,
                        metodoGetHashCode
                    );

        public bool Equals(TSource x, TSource y)
            => MetodoEquals(x, y);

        public int GetHashCode(TSource obj)
            => MetodoGetHashCode(obj);
    }
}