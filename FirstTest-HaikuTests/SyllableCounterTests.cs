using FirstTest_Haiku;
using FluentAssertions;
using NUnit.Framework;

namespace FirstTest_HaikuTests
{
    [TestFixture]
    public class SyllableCounterTests
    {
        [TestCase]
        public void Count_2Consecutive_Returns1()
        {
            new SyllableCounter().Count("aah").Should().Be(1, "Because aah has two consecutive vowels");
        }

        [TestCase]
        public void Count_2NonConsecutive_Returns2()
        {
            new SyllableCounter().Count("aha").Should().Be(2, "Because has two non-consecutive vowels");
        }

        [TestCase]
        public void Count_SomeWordWith6Syllabels_Returns6()
        {
            //'a', 'e', 'i', 'o', 'u','y'
            new SyllableCounter().Count("aakceezxiimnboowduulkyyy").Should().Be(6, "Because has two non-consecutive vowels");
        }

    }
}


