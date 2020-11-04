namespace PierreARNAUDET.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        static readonly Random random = new Random();

        public static T FirstOrDefaultValue<T>(this IEnumerable<T> source, T defaultValue) => source.DefaultIfEmpty(defaultValue).First();

        public static T FirstOrDefaultValue<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue) => source.Where(predicate).DefaultIfEmpty(defaultValue).First();

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) { action(item); }
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
        {
            return source.Except(new[] { item });
        }

        /// <summary>
        /// Try to avoid: if you need to know indexes, please see IList
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var found = source.Select((a, i) => new { a, i }).FirstOrDefault(x => comparer.Equals(x.a, item));
            return found == null ? -1 : found.i;
        }

        public static T GetRandom<T>(this IEnumerable<T> source)
        {
            var array = source.ToList();
            return array[random.Next(array.Count)];
        }

        public static T GetRandom<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            if (func == null)
            {
                return source.GetRandom();
            }
            return source.Where(func).GetRandom();
        }

        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> enumerable) => enumerable.All(source.Contains);

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            var res = source.ToList();
            var count = res.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = UnityEngine.Random.Range(i, count);
                var tmp = res[i];
                res[i] = res[r];
                res[r] = tmp;
            }
            return res;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> property) => source.GroupBy(property).Select(x => x.First());

        public static string Join<T>(this IEnumerable<T> source, string separator) => string.Join(separator, source);

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();
    }
}