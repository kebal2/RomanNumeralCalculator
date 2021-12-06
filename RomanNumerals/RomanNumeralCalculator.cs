/*
 * In the following code, "romanNumeral" refers to the symbol such as "V", and the RomanNumeralValue refers to the value such as 5.
 *
 * How the code works:
 * Find the two roman numerals that your input fits in between.
 * eg if your input is 90, your lowerRomanNumeralValue is 50, and upperRomanNumeralValue is 100
 *
 * If the difference between the upperRomanNumeralValue and your input (eg. 100 - 90 = 10) is <= the next lower power of 10 roman numeral (eg. 10),
 * then put the lower power of 10 roman numeral in front of the upperRomanNumeralValue and this will be the first part of your output (eg. "XC").
 *
 * If the difference between the upperRomanNumeralValue and your input (eg. 100 - 80 = 20) is NOT <= the next lower power of 10 roman numeral (eg. 10),
 * then the lowerRomanNumeralValue (eg 50) will be the first part of your output (eg. "L").
 *
 * To calculate the next part of the output, you need to find out what you have left to calculate,
 * which is your original input minus whatever you currently have as the first part of your output.
 * Eg. if you had 80, then your first part of the output would be "L" which is 50, 80 - 50 = 30 is the next input for the above process.
 *
 * Continue with the above process until the value of the next bit to calculate is 0, in which case you display your output.
 */

using System;
using System.Collections.Specialized;
using System.Text;

namespace RomanNumerals
{
    public static class RomanNumeralCalculator
    {
        private static readonly OrderedDictionary RomanNumerals = new OrderedDictionary
        {
            { "I", 1 }, { "V", 5 }, { "X", 10 }, { "L", 50 }, { "C", 100 }, { "D", 500 }, { "M", 1000 }, { "V`", 5000 },
            { "X`", 10000 }, { "L`", 50000 }, { "C`", 100000 }, { "D`", 500000 }, { "M`", 1000000 }
        };

        public static string AsRomanNumeral(this int currentInput, Boundaries boundaries)
        {
            if (!InputValidator.IsInputValid(currentInput, boundaries)) return String.Empty;

            StringBuilder answer = new StringBuilder();

            if (IsInputEqualToOneOfTheRomanNumerals(currentInput)) return GetRomanNumeralFromValue(currentInput);

            int nextInput;
            if (IsInputLargerThanLargestRomanNumeralValue(currentInput))
            {
                var largestRomanNumeralValue = GetLargestRomanNumeralValue();
                var largestRomanNumeral = GetRomanNumeralFromValue(largestRomanNumeralValue);

                answer.Append(largestRomanNumeral);

                nextInput = currentInput - largestRomanNumeralValue;
            }
            else
            {
                var lowerRomanNumeralValue = GetLowerRomanNumeralValue(currentInput);
                var upperRomanNumeralValue = GetUpperRomanNumeralValue(lowerRomanNumeralValue);
                var upperRomanNumeralValueMinusInput = upperRomanNumeralValue - currentInput;
                var lowerPowerOfTenRomanNumeralValue = GetLowerPowerOfTenRomanNumeralValue(lowerRomanNumeralValue, upperRomanNumeralValue);

                if (CanInputBeWrittenAsSmallerNumeralInFrontOfLargerNumeral(upperRomanNumeralValueMinusInput, lowerPowerOfTenRomanNumeralValue))
                {
                    var lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral = ConcatenateRomanNumeralsFromValues(lowerPowerOfTenRomanNumeralValue, upperRomanNumeralValue);
                    var lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue = upperRomanNumeralValue - lowerPowerOfTenRomanNumeralValue;

                    answer.Append(lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral);

                    nextInput = currentInput - lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue;
                }
                else
                {
                    answer.Append(GetRomanNumeralFromValue(lowerRomanNumeralValue));

                    nextInput = currentInput - lowerRomanNumeralValue;
                }
            }

            answer.Append(AsRomanNumeral(nextInput));

            return answer.ToString();
        }

        public static string AsRomanNumeral(this int currentInput) => AsRomanNumeral(currentInput, new Boundaries());

        private static bool CanInputBeWrittenAsSmallerNumeralInFrontOfLargerNumeral(int upperRomanNumeralValueMinusInput, int lowerPowerOfTenRomanNumeralValue) => upperRomanNumeralValueMinusInput <= lowerPowerOfTenRomanNumeralValue;

        private static bool IsInputEqualToOneOfTheRomanNumerals(int currentInput) => RomanNumerals.ContainsValue(currentInput);

        private static bool IsInputLargerThanLargestRomanNumeralValue(int input) => input > GetLargestRomanNumeralValue();

        private static int GetLargestRomanNumeralValue() => GetRomanNumeralValueAtIndex(RomanNumerals.Count - 1);

        private static int GetLowerPowerOfTenRomanNumeralValue(int lowerRomanNumeralValue, int upperRomanNumeralValue)
        {
            var lowerPowerOfTenRomanNumeralValue = lowerRomanNumeralValue;

            if (MathCalculator.IsValuePowerOfTen(upperRomanNumeralValue)) lowerPowerOfTenRomanNumeralValue = GetNextLowerPowerOfTenRomanNumeral(lowerRomanNumeralValue);

            return lowerPowerOfTenRomanNumeralValue;
        }

        private static string ConcatenateRomanNumeralsFromValues(int beforeRomanNumeralValue, int afterRomanNumeralValue)
        {
            var lowerRomanNumeralPowerOfTen = GetRomanNumeralFromValue(beforeRomanNumeralValue);
            var upperRomanNumeral = GetRomanNumeralFromValue(afterRomanNumeralValue);
            return lowerRomanNumeralPowerOfTen + upperRomanNumeral;
        }

        private static int GetNextLowerPowerOfTenRomanNumeral(int currentValue)
        {
            var lowerPowerOfTenRomanNumeralValue = 0;
            if (MathCalculator.IsValuePowerOfTen(currentValue))
            {
                lowerPowerOfTenRomanNumeralValue = currentValue;
            }
            else
            {
                var lowerRomanNumeralIndex = RomanNumerals.IndexOfValue(currentValue);
                for (var i = lowerRomanNumeralIndex; i >= 0; i--)
                {
                    var currentRomanNumeralValue = GetRomanNumeralValueAtIndex(i);
                    if (MathCalculator.IsValuePowerOfTen(currentRomanNumeralValue))
                    {
                        lowerPowerOfTenRomanNumeralValue = currentRomanNumeralValue;
                        break;
                    }
                }
            }

            return lowerPowerOfTenRomanNumeralValue;
        }

        private static int GetUpperRomanNumeralValue(int lowerRomanNumeralValue)
        {
            var indexOfLowerRomanNumeral = RomanNumerals.IndexOfValue(lowerRomanNumeralValue);
            var upperRomanNumeralValue = GetRomanNumeralValueAtIndex(indexOfLowerRomanNumeral + 1);
            return upperRomanNumeralValue;
        }

        private static int GetLowerRomanNumeralValue(int input)
        {
            for (var i = RomanNumerals.Count - 1; i >= 0; i--)
            {
                var romanNumeralValue = GetRomanNumeralValueAtIndex(i);

                if (romanNumeralValue <= input) return romanNumeralValue;
            }

            throw new LowerRomanNumeralNotFoundException();
        }

        private static int GetRomanNumeralValueAtIndex(int index) => (int)RomanNumerals[index];

        private static string GetRomanNumeralFromValue(int value) => (string)RomanNumerals.GetKeyFromFirstElementWithValue(value);
    }
}