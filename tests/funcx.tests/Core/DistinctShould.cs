﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class DistinctShould
    {
        [Test]
        public void Distinct_should_return_lazy_list_of_distinct_values()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(1, 2, 3, 4, 5);
            var actual = new ToArray().Invoke(new Distinct().Invoke(new Vector().Invoke(1, 2, 1, 3, 1, 4, 1, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}
