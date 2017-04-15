using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosestColor
{
    // ReSharper disable once InconsistentNaming
    internal static class IReadOnlyListExtensions
    {
        public static ISet<int> FindAllIndexes<T>(this IReadOnlyList<T> data, Func<T, bool> predicate)
        {
            var result = new HashSet<int>();
            for (var i = 0; i < data.Count(); i++)
            {
                if (predicate(data[i]))
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}