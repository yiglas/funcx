﻿namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
         /// Returns a lazy sequence of all but the first n items in coll.
         /// </summary>
         /// <typeparam name="T">Generic type of the collection.</typeparam>
         /// <param name="source">The <see cref="IEnumerable{T}"/>.</param>
         /// <param name="n">The number of items to drop from the beginning</param>
         /// <returns>
         /// An <see cref="IEnumerable"/> loaded as requested of items excluding the first n items.
         /// </returns>
        public static IEnumerable<T> drop<T>(this IEnumerable<T> source, int n)
        {
            if (truthy(and(source, n > 0)))
            {
                int i = 1;
                foreach (var item in source)
                    if (i++ <= n) continue; else yield return item;
            }

            yield break;
        }


        /// <summary>
        /// Returns a lazy sequence of all but the first n items in coll.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable"/>.</param>
        /// <param name="n">The number of items to drop from the beginning</param>
        /// <returns>
        /// An <see cref="IEnumerable"/> loaded as requested of items excluding the first n items.
        /// </returns>
        public static IEnumerable drop(this IEnumerable source, int n)
        {
            if (truthy(and(source, n > 0)))
            {
                int i = 1;
                foreach (var item in source)
                    if (i++ <= n) continue; else yield return item;
            }

            yield break;
        }
    }
}
