﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise <see cref="false"/>.
    /// </summary>
    public class IsInt :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) =>
            new Or().Invoke(
                n is int,
                n is long,
                n is short,
                n is byte);
    }
}