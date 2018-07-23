﻿using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of all but the first n items in coll.
    /// </summary>
    public class Drop :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object n) => new Function<object, object>(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of all but the first n items in coll.
        /// </summary>
        /// <param name="n">An <see cref="int"/> of the items to drop from the collection.</param>
        /// <param name="coll">The collection to drop the first x items from.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of items without the first x items.
        /// </returns>
        public object Invoke(object n, object coll) => lazySeq(() => step(n, coll));

        object step(object n, object coll)
        {
            var s = seq(coll);
            if ((bool)new Truthy().Invoke(and(isPos(n), s)))
            {
                return step(dec(n), rest(s));
            }
            return s;
        }

        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _nv;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._nv = (Volatileǃ)new Volatileǃ().Invoke(n);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var n = this._nv.Deref();
                new VSwapǃ(this._nv, new Dec());
                if ((bool)isPos(n))
                    return result;

                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}
