using System;
using FirstTest_Haiku;
using FirstTest_Haiku.Util;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace FirstTest_HaikuTests
{
    [TestFixture]
    class HaikuParserTests
    {
        [TestCase]
        public void ParseHaiku_IsHsHaiku_575y()
        {
            string input = "Friday is so bright/Fills my heart with such delight/Soon my feet took flight";

            ResultOfParsingHaiku result = new HaikuParser(new SyllableCounter(), new Mock<IConsoleWrapper>().Object).ParseHaiku(input);

            result.ToString().Should().Be("5,7,5,y");
        }

        [TestCase]
        public void ParseHaiku_NotHaiku_675n()
        {
            string input = "Friday is also bright/Fills my heart with such delight/Soon my feet took flight";

            ResultOfParsingHaiku result = new HaikuParser(new SyllableCounter(), new Mock<IConsoleWrapper>().Object).ParseHaiku(input);

            result.ToString().Should().Be("6,7,5,n");
        }

        [TestCase]
        public void ParseHaiku_NotHaiku_5n()
        {
            string input = "Friday is so bright";

            ResultOfParsingHaiku result = new HaikuParser(new SyllableCounter(), new Mock<IConsoleWrapper>().Object).ParseHaiku(input);

            result.ToString().Should().Be("5,n");
        }

        [TestCase]
        public void ParseHaiku_NotHaiku_n()
        {
            string input = "";

            ResultOfParsingHaiku result = new HaikuParser(new SyllableCounter(), new Mock<IConsoleWrapper>().Object).ParseHaiku(input);

            result.ToString().Should().Be("n");
        }

        [TestCase]
        public void ParseHaikus_2LinesBothHaiku_575ynl575y()
        {
            string input = "Friday is so bright/Fills my heart with such delight/Soon my feet took flight";
            input = input + Environment.NewLine + input;

            Mock<IConsoleWrapper> mockOfConsoleWrapper = new Mock<IConsoleWrapper>();

            new HaikuParser(new SyllableCounter(), mockOfConsoleWrapper.Object).ParseHaikus(input);

            mockOfConsoleWrapper.Verify(x => x.WriteLine("5,7,5,y"), Times.Exactly(2));
        }

        [TestCase]
        public void ParseHaikus_ArgumentNull_ThrowsArgumentNullException()
        {
            Action action = () => new HaikuParser(new SyllableCounter(), new Mock<IConsoleWrapper>().Object).ParseHaikus(null);

            action.Should().Throw<ArgumentNullException>();
        }

    }
}
