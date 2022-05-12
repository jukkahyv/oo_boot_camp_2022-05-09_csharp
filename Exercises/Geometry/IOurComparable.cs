/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.rectangle
{
    public interface IOurComparable<T>
    {
        bool BetterThan(T champion);
    }

    public static class OurComparableExtensions
    {
        public static T? Best<T>(this IEnumerable<T> items)
            where T : class, IOurComparable<T>
        {
            //return rectangles.MaxBy(r => r.Area());
            /*T? champion = null;
            foreach (var challenger in items)
            {
                if (champion == null || challenger.BetterThan(champion))
                {
                    champion = challenger;
                }
            }
            return champion;*/
            return items.Best((challenger, champion) => challenger.BetterThan(champion));
        }

        public static T? Best<T>(this IEnumerable<T> items,
            Func<T, T, bool> better) where T : class
        {
            //return rectangles.MaxBy(r => r.Area());
            T? champion = null;
            foreach (var challenger in items)
            {
                if (champion == null || better(challenger, champion))
                {
                    champion = challenger;
                }
            }
            return champion;
        }
    }
}