using System;
using System.Collections.Generic;
using MattEland.Shared.Collections;
using NUnit.Framework;
using Shouldly;

namespace MattEland.Shared.Tests
{
    /// <summary>
    /// Tests oriented around hash sets
    /// </summary>
    public class SetTests
    {
        [Test]
        public void CollectionElementsShouldExistInConvertedHashSet()
        {
            // Arrange
            var source = new List<int> {42, 301, 4};

            // Act
            var set = source.ToHashSet();

            // Assert
            source.Each(i => set.Contains(i).ShouldBeTrue());
        }

        [Test]
        public void CollectionToHashSetShouldCreateWhenSourceIsNull()
        {
            // Arrange
            List<int> source = null;

            // Act
            var set = source.ToHashSet();

            // Assert
            set.ShouldNotBeNull();

        }

        [Test]
        public void CollectionToHashSetShouldCreateWhenSourceIsEmpty()
        {
            // Arrange
            var source = new List<int>();

            // Act
            var set = source.ToHashSet();

            // Assert
            set.ShouldNotBeNull();

        }
    }
}
