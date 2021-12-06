using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace RomanNumeralsTests
{
    [TestClass]
    public class RomanNumeralsTests
    {
        [TestMethod]
        public void GivenInteger1_WhenConvertedToRomanNumeral_AssertThatItsI()
        {
            var romanNumeral = 1.AsRomanNumeral();
            Assert.AreEqual("I", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger5_WhenConvertedToRomanNumeral_AssertThatItsV()
        {
            var romanNumeral = 5.AsRomanNumeral();
            Assert.AreEqual("V", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger10_WhenConvertedToRomanNumeral_AssertThatItsX()
        {
            var romanNumeral = 10.AsRomanNumeral();
            Assert.AreEqual("X", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger50_WhenConvertedToRomanNumeral_AssertThatItsL()
        {
            var romanNumeral = 50.AsRomanNumeral();
            Assert.AreEqual("L", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger100_WhenConvertedToRomanNumeral_AssertThatItsC()
        {
            var romanNumeral = 100.AsRomanNumeral();
            Assert.AreEqual("C", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger500_WhenConvertedToRomanNumeral_AssertThatItsD()
        {
            var romanNumeral = 500.AsRomanNumeral();
            Assert.AreEqual("D", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger1000_WhenConvertedToRomanNumeral_AssertThatItsM()
        {
            var romanNumeral = 1000.AsRomanNumeral();
            Assert.AreEqual("M", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger900_WhenConvertedToRomanNumeral_AssertThatItsCM()
        {
            var romanNumeral = 900.AsRomanNumeral();
            Assert.AreEqual("CM", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger90_WhenConvertedToRomanNumeral_AssertThatItsXC()
        {
            var romanNumeral = 90.AsRomanNumeral();
            Assert.AreEqual("XC", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger9_WhenConvertedToRomanNumeral_AssertThatItsIX()
        {
            var romanNumeral = 9.AsRomanNumeral();
            Assert.AreEqual("IX", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger909_WhenConvertedToRomanNumeral_AssertThatItsCMIX()
        {
            var romanNumeral = 909.AsRomanNumeral();
            Assert.AreEqual("CMIX", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger999_WhenConvertedToRomanNumeral_AssertThatItsCMXCIX()
        {
            var romanNumeral = 999.AsRomanNumeral();
            Assert.AreEqual("CMXCIX", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger49_WhenConvertedToRomanNumeral_AssertThatItsXLIX()
        {
            var romanNumeral = 49.AsRomanNumeral();
            Assert.AreEqual("XLIX", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger400_WhenConvertedToRomanNumeral_AssertThatItsCD()
        {
            var romanNumeral = 400.AsRomanNumeral();
            Assert.AreEqual("CD", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger40_WhenConvertedToRomanNumeral_AssertThatItsXL()
        {
            var romanNumeral = 40.AsRomanNumeral();
            Assert.AreEqual("XL", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger4_WhenConvertedToRomanNumeral_AssertThatItsIV()
        {
            var romanNumeral = 4.AsRomanNumeral();
            Assert.AreEqual("IV", romanNumeral);
        }

        [TestMethod]
        public void GivenInteger723_WhenConvertedToRomanNumeral_AssertThatItsDCCXXIII()
        {
            var romanNumeral = 723.AsRomanNumeral();
            Assert.AreEqual("DCCXXIII", romanNumeral);
        }
    }
}