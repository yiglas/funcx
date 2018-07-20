﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsNotEveryShould
    {
        [Test]
        public void IsNotEvery_should_return_true_if_a_collection_does_not_contain_any_odd()
        {
            Assert.IsTrue((bool)new IsNotEvery().Invoke(new IsOdd(), new funclib.Components.Core.List().Invoke(1, 2, 3)));
        }

        [Test]
        public void IsNotEvery_should_return_false_if_a_collection_does_contain_odd()
        {
            Assert.IsFalse((bool)new IsNotEvery().Invoke(new IsOdd(), new funclib.Components.Core.List().Invoke(1, 3)));
        }
    }
}