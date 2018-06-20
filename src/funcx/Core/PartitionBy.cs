﻿using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class PartitionBy :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => new Function<object, object>(rf => new TransducerFunction(f, rf));
        public object Invoke(object f, object coll) =>
            new LazySeq(() =>
            {
                var fn = ((IFunction<object, object>)f);
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var fst = s.First();
                    var fv = fn.Invoke(fst);
                    var run = new Cons().Invoke(fst, new TakeWhile().Invoke(new Function<object, object>(x => new Equals().Invoke(fv, fn.Invoke(x))), s.Next()));

                    return new Cons().Invoke(run, Invoke(f, new Seq().Invoke(new Drop().Invoke(new Count().Invoke(run), s))));
                }
                return null;
            });

        public class TransducerFunction :
            ATransducerFunction
        {
            System.Collections.ArrayList _a;
            Volatile _pv;
            object _f;

            public TransducerFunction(object f, object rf) :
                base(rf)
            {
                this._f = f;
                this._a = new System.Collections.ArrayList();
                this._pv = (Volatile)new Volatile_().Invoke("::none");
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if (!(bool)new IsZero().Invoke(this._a.Count))
                {
                    var v = new Vec().Invoke(this._a.ToArray());
                    this._a.Clear();
                    result = new Unreduce().Invoke(((IFunction<object, object, object>)this._rf).Invoke(result, v));
                }

                return ((IFunction<object, object>)this._rf).Invoke(result);
            }
            public override object Invoke(object result, object input)
            {
                var pval = this._pv.Deref();
                var val = ((IFunction<object, object>)this._f).Invoke(input);
                new VReset_().Invoke(this._pv, val);
                if ((bool)new Truthy().Invoke(new Or().Invoke(new IsIdentical().Invoke(pval, "::none"), new Equals().Invoke(val, pval))))
                {
                    this._a.Add(input);
                    return result;
                }

                var v = new Vec().Invoke(this._a.ToArray());
                this._a.Clear();
                var ret = ((IFunction<object, object, object>)this._rf).Invoke(result, v);

                if (!(bool)new Reduced().Invoke(ret))
                    this._a.Add(input);

                return ret;
            }
            #endregion
        }
    }
}
