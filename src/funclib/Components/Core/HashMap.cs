﻿using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings. If any keys are
    /// equal, they are handled as if by repeated uses of <see cref="funclib.Components.Core.Assoc"/>.
    /// </summary>
    public class HashMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings. If any keys are
        /// equal, they are handled as if by repeated uses of <see cref="funclib.Components.Core.Assoc"/>.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.HashMap.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.HashMap.EMPTY;
        /// <summary>
        /// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings. If any keys are
        /// equal, they are handled as if by repeated uses of <see cref="funclib.Components.Core.Assoc"/>.
        /// </summary>
        /// <param name="keyvals">Key/value pairs adding to the <see cref="Collections.HashMap"/> data structure.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings.
        /// </returns>
        public object Invoke(params object[] keyvals) => Collections.HashMap.Create(keyvals);
    }
}
