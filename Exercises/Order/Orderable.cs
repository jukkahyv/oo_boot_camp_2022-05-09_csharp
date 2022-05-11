/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

namespace Exercises.Order {
    // Understands a sequence of an aggregation
    public interface Orderable<T> {
        bool IsBetterThan(T other);
    }

    // Understands operations on sequences
    public static class OrderExtensions {
        public static T Best<T>(this List<T> challengers) where T : Orderable<T> {
            var champion = challengers.First();
            foreach (var challenger in challengers) {
                if (challenger.IsBetterThan(champion)) champion = challenger;
            }
            return champion;
        }
    }
}