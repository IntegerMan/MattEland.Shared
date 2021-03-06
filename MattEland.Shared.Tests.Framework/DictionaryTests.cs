﻿using System;
using System.Collections.Generic;
using System.Text;
using MattEland.Shared.Collections;
using NUnit.Framework;
using Shouldly;

namespace MattEland.Shared.Tests
{
    /// <summary>
    /// Tests related specifically to Dictionaries.
    /// </summary>
    public class DictionaryTests
    {
        [Test]
        public void TryLoadShouldErrorIfNoOperation()
        {
            // Arrange
            var dict = new Dictionary<int, int> {[1] = 42};

            // Act
            Should.Throw<ArgumentNullException>(() => dict.TryLoad(1, null));
        }

        [Test]
        public void TryLoadShouldNotErrorWithNullDictionary()
        {
            // Arrange
            Dictionary<int, int> dict = null;

            // Act / Assert
            dict.TryLoad(1, v => throw new ShouldAssertException("No operation expected"));
        }

        [Test]
        public void TryLoadShouldNotErrorWithEmptyDictionary()
        {
            // Arrange
            var dict = new Dictionary<int, int>();

            // Act / Assert
            bool result = dict.TryLoad(1, v => throw new ShouldAssertException("No operation expected"));
            result.ShouldBeFalse();
        }

        [Test]
        public void TryLoadShouldInvokeWithTheCorrectValue()
        {
            // Arrange
            var dict = new Dictionary<int, int> {[1] = 42, [0] = 19};
            int actual = 0;

            // Act
            bool result = dict.TryLoad(1, v => actual = v);

            // Assert
            result.ShouldBeTrue();
            actual.ShouldBe(42);
        }
    }
}
