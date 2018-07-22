﻿using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
    /// </summary>
    public class Distinct :
        IFunction<object>,
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="IFunction{T1, TResult}"/> that returns a <see cref="TransducerFunction"/>.
        /// </returns>
        public object Invoke() => new Function<object, object>(rf => new TransducerFunction(rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
        /// </summary>
        /// <param name="coll">A collection of items to return distinct with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of unique items from coll.
        /// </returns>
        public object Invoke(object coll)
        {
            return step(coll, hashSet());

            object step(object xs, object seen) =>
                new LazySeq(() => new Function().Invoke(xs, seen));
        }


        class Function :
            IFunction<object, object, object>
        {
            public object Invoke(object xs, object seen)
            {
                var f = first(xs);
                var s = new Seq().Invoke(xs);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)contains(seen, f))
                    {
                        return Invoke(new Rest().Invoke(s), seen);
                    }

                    return cons(f, Invoke(new Rest().Invoke(s), conj(seen, f)));
                }

                return null;
            }
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _seen;

            public TransducerFunction(object rf) :
                base(rf)
            {
                this._seen = (Volatileǃ)new Volatileǃ().Invoke(hashSet());
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)contains(this._seen, input))
                {
                    return result;
                }

                new VSwapǃ(this._seen, new Conj(), input).Invoke();
                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}
