﻿using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsPosInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) =>
            and(
                new IsInt().Invoke(n),
                new IsPos().Invoke(n));
    }
}