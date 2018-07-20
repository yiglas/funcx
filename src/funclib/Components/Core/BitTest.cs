﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    public class BitTest :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.TestBit(x, n);
    }
}