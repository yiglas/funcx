﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class NFirst :
        IFunction<object, object>
    {
        public object Invoke(object x) => new Next().Invoke(new First().Invoke(x));
    }
}
