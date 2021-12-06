using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace RomanNumeralsTests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void GivenValue_WhenCheckingIfDictionaryContainsIt_AssertThatItExists()
        {
            var dict = new OrderedDictionary { { 'V', 5 }, { 'X', 10 }, { 'L', 50 } };
            Assert.IsTrue(dict.ContainsValue(5));
        }

        [TestMethod]
        public void GivenValue_WhenCheckingIfDictionaryContainsIt_AssertThatItDoesNotExists()
        {
            var dict = new OrderedDictionary { { 'V', 5 }, { 'X', 10 }, { 'L', 50 } };
            Assert.IsFalse(dict.ContainsValue(52));
        }
    }
}