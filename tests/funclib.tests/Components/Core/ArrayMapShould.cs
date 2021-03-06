﻿using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ArrayMapShould
    {
        [Test]
        public void ArrayMap_should_return_empty_map_when_no_parameters_passed()
        {
            var expected = 0;
            var actual = funclib.Core.ArrayMap();

            Assert.AreEqual(expected, funclib.Core.Count(actual));
        }
    }
}
