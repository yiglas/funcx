﻿using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections
{
    public class Repeat :
        ASeq,
        IReduce
    {
        const long INFINITE = -1;

        readonly long _count;
        readonly object _val;
        volatile ISeq _next;

        Repeat(long count, object val)
        {
            this._count = count;
            this._val = val;
        }

        #region Creates
        public static ISeq Create(object val) => new Repeat(INFINITE, val);
        public static ISeq Create(long count, object val) => count <= 0 ? List.EMPTY : new Repeat(count, val);
        #endregion

        #region Overrides
        public override object First() => this._val;
        public override ISeq Next() =>
            this._next != null
                ? this._next
                : this._count > 1 ? this._next = new Repeat(this._count - 1, this._val)
                : this._count == INFINITE ? this._next = this
                : this._next;

        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public object Reduce(IFunction f)
        {
            var ret = this._val;
            if (this._count == INFINITE)
            {
                while (true)
                {
                    ret = ((IFunction<object, object, object>)f).Invoke(ret, this._val);
                    if (ret is Reduced r)
                        return r.Deref();
                }
            }
            else
            {
                for (long i = 1;  i < this._count; i++)
                {
                    ret = ((IFunction<object, object, object>)f).Invoke(ret, this._val);
                    if (ret is Reduced r)
                        return r.Deref();
                }

                return ret;
            }
        }
        public object Reduce(IFunction f, object init)
        {
            var ret = init;
            if (this._count == INFINITE)
            {
                while (true)
                {
                    ret = ((IFunction<object, object, object>)f).Invoke(ret, this._val);
                    if (ret is Reduced r)
                        return r.Deref();
                }
            }
            else
            {
                for (long i = 0; i < this._count; i++)
                {
                    ret = ((IFunction<object, object, object>)f).Invoke(ret, this._val);
                    if (ret is Reduced r)
                        return r.Deref();
                }

                return ret;
            }
        }
    }
}
