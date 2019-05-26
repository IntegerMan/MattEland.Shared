using System;
using System.Collections.Generic;
using System.Text;
using MattEland.Shared.Strings;
using NUnit.Framework;
using Shouldly;

namespace MattEland.Shared.Tests
{
    /// <summary>
    /// Tests around the <see cref="IndentingStringBuilder"/> class.
    /// </summary>
    public class StringIndentTests
    {

        [Test]
        public void StringIndentShouldIndentStrings()
        {
            // Arrange
            var sb = new IndentingStringBuilder();

            // Act
            sb.AppendLine("Hello There");
            sb.Indent();
            sb.AppendLine("General Kenobi!");
            string output = sb.ToString();

            // Assert
            output.ShouldBe("Hello There\r\n\tGeneral Kenobi!\r\n");
        }

        [Test]
        public void StringIndentWithScopeShouldOutdent()
        {
            // Arrange
            var sb = new IndentingStringBuilder();

            // Act
            sb.AppendLine("Foo");
            using (sb.IndentScope())
            {
                sb.AppendLine("Bar");
            }
            sb.AppendLine("Baz");
            string output = sb.ToString();

            // Assert
            output.ShouldBe("Foo\r\n\tBar\r\nBaz\r\n");
        }

        [Test]
        public void StringBuilderRespectsSourceString()
        {
            // Arrange
            var sb = new IndentingStringBuilder("Such\r\n");

            // Act
            sb.AppendLine();
            sb.AppendLine("Doggo");
            string output = sb.ToString();

            // Assert
            output.ShouldBe("Such\r\n\r\nDoggo\r\n");
        }
    }
}
