﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class KeepShould
    {
        [Test]
        public void Keep_should_return_return_return_list_with_results()
        {
            var expected = new funclib.Components.Core.List().Invoke(false, true, false, true, false, true, false, true, false);
            var actual = new Keep().Invoke(new IsEven(), new Range().Invoke(1, 10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_return_values_from_function()
        {
            var expected = new funclib.Components.Core.List().Invoke(1, 3, 5, 7, 9);
            var actual = new Keep().Invoke(new Function<object, object>(x => (bool)new IsOdd().Invoke(x) ? x : null), new Range().Invoke(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_be_able_to_be_used_with_maps()
        {
            var expected = new funclib.Components.Core.List().Invoke(1, 2);
            var actual = new Keep().Invoke(arrayMap(":a", 1, ":b", 2, ":c", 3), new Vector().Invoke(":a", ":b", ":d"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_be_able_to_be_used_with_sets()
        {
            var expected = new funclib.Components.Core.List().Invoke(2, 3);
            var actual = new ToArray().Invoke(new Keep().Invoke(hashSet(0, 1, 2, 3), hashSet(2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}
