using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Parliament.Common.Extensions
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static List<TBatch> SelectToListBatch<T, TBatch>(this IList<T> items, Func<List<T>, int, int, TBatch> batchAction, int maxNumberOfItemsInBatch)
        {
            int skip = 0;
            var batchIndex = 0;
            var results = new List<TBatch>();
            while (skip < items.Count())
            {
                var batchResult = batchAction(items.Skip(skip).Take(maxNumberOfItemsInBatch).ToList(), batchIndex, skip);
                results.Add(batchResult);
                skip += maxNumberOfItemsInBatch;
                batchIndex++;
            }

            return results;
        }

        [DebuggerStepThrough]
        public static void Batch<T>(this IList<T> items, Action<IList<T>> batchAction, int maxNumberOfItemsInBatch)
        {
            int skip = 0;
            while (skip < items.Count())
            {
                batchAction(items.Skip(skip).Take(maxNumberOfItemsInBatch).ToList());
                skip += maxNumberOfItemsInBatch;
            }
        }

        [DebuggerStepThrough]
        public static void BatchedForEach<T>(this IList<T> items, Action<T> action, Action batchAction,
            int numberOfItemsBeforeBatchAction)
        {
            items.ForEachIndex((x, i) =>
            {
                action(x);
                if (i % numberOfItemsBeforeBatchAction == 0 && i > 0) batchAction();
            });
            batchAction();
        }

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items) action(item);
        }

        [DebuggerStepThrough]
        public static void ForEachIndex<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            int i = 0;
            foreach (T item in items)
            {
                action(item, i);
                i++;
            }
        }

        [DebuggerStepThrough]
        public static List<TResult> SelectToNonNullableList<T, TResult>(this IEnumerable<T> items,
            Func<T, TResult?> nullableStructSelector)
            where TResult : struct
        {
            return items.Select(nullableStructSelector)
                .ClearNulls();
        }

        [DebuggerStepThrough]
        public static List<TResult> SelectDistinctToList<T, TResult>(this IList<T> items, Func<T, TResult> selector)
        {
            return items.Select(selector).DistinctToList();
        }

        [DebuggerStepThrough]
        public static List<T> WhereToList<T>(this IEnumerable<T> items, Func<T, bool> whereFunc)
        {
            return items.Where(whereFunc).ToList();
        }

        [DebuggerStepThrough]
        public static List<T> DistinctToList<T>(this IEnumerable<T> items)
        {
            return items.Distinct().ToList();
        }

        [DebuggerStepThrough]
        public static List<T> ClearNulls<T>(this IEnumerable<T?> items)
            where T : struct
        {
            return items.Where(x => x.HasValue)
                // ReSharper disable once PossibleInvalidOperationException
                .SelectToList(x => x.Value);
        }

        [DebuggerStepThrough]
        public static List<T> UnionToList<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return first.Union(second).ToList();
        }

        [DebuggerStepThrough]
        public static List<TResult> SelectToList<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector)
        {
            return items.Select(selector).ToList();
        }

        [DebuggerStepThrough]
        public static List<TResult> ParallelSelectToList<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector)
        {
            IList<TResult> result = new List<TResult>();
            IList<T> listedItems = items as IList<T> ?? items.ToList();
            Parallel.ForEach(listedItems, x => result.Add(selector(x)));
            return listedItems.Select(selector).ToList();
        }

        [DebuggerStepThrough]
        public static List<TResult> SelectToListIndex<T, TResult>(this IEnumerable<T> items,
            Func<T, int, TResult> selector)
        {
            return items.Select(selector).ToList();
        }

        [DebuggerStepThrough]
        public static List<TResult> SelectManyToList<T, TResult>(this IEnumerable<T> items,
            Func<T, IEnumerable<TResult>> selector)
        {
            return items.SelectMany(selector).ToList();
        }

        [DebuggerStepThrough]
        public static string FlattenToString(this IList<string> items, string seperator = ",")
        {
            if (items == null) return null;
            return String.Join(seperator, items);
        }

        [DebuggerStepThrough]
        public static string FlattenToStringList<T>(this IList<T> items, string seperator = ",")
            where T : struct
        {
            if (items == null) return null;
            return String.Join(seperator, items.Select(x => x.ToString()));
        }


        [DebuggerStepThrough]
        public static List<T> OrderByToList<T, TKey>(this IEnumerable<T> items, Func<T, TKey> keySelector,
            bool orderDescending = false)
        {
            return orderDescending
                ? items.OrderByDescending(keySelector).ToList()
                : items.OrderBy(keySelector).ToList();
        }

        [DebuggerStepThrough]
        public static void ForEachRange(this DateTime startDate, DateTime endDate, TimeSpan incrementTimeSpan, Action<DateTime, DateTime> action)
        {
            for (DateTime date = startDate; date.Date <= endDate.Date; date = date.Add(incrementTimeSpan))
            {
                action(date, date.Add(incrementTimeSpan).AddTicks(-1));
            }
        }
    }
}