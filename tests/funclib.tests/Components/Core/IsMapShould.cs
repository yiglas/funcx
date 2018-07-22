﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsMapShould
    {
        [Test]
        public void IsMap_should_return_true_if_an_object_is_IMap()
        {
            Assert.IsTrue((bool)isCounted(hashMap()));
        }

        [Test]
        public void IsMap_should_return_false_if_an_object_is_not_IMap()
        {
            Assert.IsFalse((bool)isCounted(1));
            Assert.IsFalse((bool)isCounted(null));
        }
    }
}
