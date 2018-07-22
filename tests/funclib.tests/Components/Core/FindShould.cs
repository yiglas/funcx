﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FindShould
    {
        [Test]
        public void Find_should_return_KeyValuePair_if_found()
        {
            var expected = new funclib.Collections.KeyValuePair(":a", 1);
            var actual = find(new HashMap().Invoke(":a", 1, ":b", 2, ":c", 3), ":a");

            Assert.IsInstanceOf<funclib.Collections.KeyValuePair>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Find_should_return_null_when_key_doesnot_exist()
        {
            var actual = find(new HashMap().Invoke(":a", 1, ":b", 2, ":c", 3), ":d");

            Assert.IsNull(actual);
        }

        [Test]
        public void Find_should_return_KeyValuePair_where_key_is_index_value_is_item_in_vector()
        {
            var expected = new funclib.Collections.KeyValuePair(2, ":c");
            var actual = find(new Vector().Invoke(":a", ":b", ":c"), 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
