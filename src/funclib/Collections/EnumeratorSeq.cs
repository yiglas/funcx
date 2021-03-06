﻿using funclib.Components.Core.Generic;

namespace funclib.Collections.Internal
{
    public class EnumeratorSeq :
        IFunction<object>
    {
        System.Collections.IEnumerator _enumerator;

        EnumeratorSeq(System.Collections.IEnumerator enumerator)
        {
            this._enumerator = enumerator;
        }

        #region Creates
        public static ISeq Create(System.Collections.IEnumerator enumerator) => !enumerator.MoveNext() ? null : funclib.Core.LazySeq(new EnumeratorSeq(enumerator)); 
        #endregion

        #region Functions
        public object Invoke()
        {
            var arr = new object[Constants.CHUNK_SIZE];
            var more = true;
            int n = 0;
            for (; n < Constants.CHUNK_SIZE && more; ++n)
            {
                arr[n] = this._enumerator.Current;
                more = this._enumerator.MoveNext();
            }

            return new ChunkedCons(new ArrayChunked(arr, 0, n), more ? Create(this._enumerator) : null);
        }
        #endregion
    }
}
