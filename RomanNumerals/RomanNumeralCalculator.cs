﻿/* 
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public static class RomanNumeralCalculator
    {        
        private static OrderedDictionary _romanNumerals = new OrderedDictionary()
        { 
            {"I", 1}, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500}, {"M", 1000}, {"V`", 5000}, {"X`", 10000}, {"L`", 50000}, {"C`", 100000}, {"D`", 500000}, {"M`", 1000000}
        };        

        public static string CalculateRomanNumeral(int currentInput)
        {
            string answer = "";
            if (InputValidator.IsInputValid(currentInput))
            {
                if (_romanNumerals.ContainsValue(currentInput))
                {
                    string romanNumeral = GetRomanNumeralFromValue(currentInput);
                    return romanNumeral;
                }

                int lowerRomanNumeralValue = GetLowerRomanNumeralValue(currentInput);
                int upperRomanNumeralValue = GetUpperRomanNumeralValue(lowerRomanNumeralValue);
                int upperRomanNumeralValueMinusInput = upperRomanNumeralValue - currentInput;
                int lowerPowerOfTenRomanNumeralValue = GetLowerPowerOfTenRomanNumeralValue(lowerRomanNumeralValue, upperRomanNumeralValue);

                int nextInput = 0;

                if (upperRomanNumeralValueMinusInput <= lowerPowerOfTenRomanNumeralValue)
                {
                    string lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral = ConcatenateRomanNumeralsFromValues(lowerPowerOfTenRomanNumeralValue, upperRomanNumeralValue);
                    int lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue = upperRomanNumeralValue - lowerPowerOfTenRomanNumeralValue;
                    answer += lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral;                    
                    nextInput = currentInput - lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue;
                }
                else
                {
                    answer += GetRomanNumeralFromValue(lowerRomanNumeralValue);
                    nextInput = currentInput - lowerRomanNumeralValue;
                }
                answer += CalculateRomanNumeral(nextInput);
            }
            return answer;
        }
        
        private static int GetLowerPowerOfTenRomanNumeralValue(int lowerRomanNumeralValue, int upperRomanNumeralValue)
        {
            int lowerPowerOfTenRomanNumeralValue = lowerRomanNumeralValue;

            if (MathCalculator.IsValuePowerOfTen(upperRomanNumeralValue))
            {
                lowerPowerOfTenRomanNumeralValue = GetNextLowerPowerOfTenRomanNumeral(lowerRomanNumeralValue);
            }
            return lowerPowerOfTenRomanNumeralValue;
        }

        private static string ConcatenateRomanNumeralsFromValues(int beforeRomanNumeralValue, int afterRomanNumeralValue)
        {
            string lowerRomanNumeralPowerOfTen = GetRomanNumeralFromValue(beforeRomanNumeralValue);
            string upperRomanNumeral = GetRomanNumeralFromValue(afterRomanNumeralValue);
            return lowerRomanNumeralPowerOfTen + upperRomanNumeral;
        }

        private static int GetNextLowerPowerOfTenRomanNumeral(int currentValue)
        {
            int lowerPowerOfTenRomanNumeralValue = 0;
            if (MathCalculator.IsValuePowerOfTen(currentValue))
            {
                lowerPowerOfTenRomanNumeralValue = currentValue;
            }
            else
            {
                int lowerRomanNumeralIndex = _romanNumerals.IndexOfValue(currentValue);
                for (int i = lowerRomanNumeralIndex; i >= 0; i--)
                {
                    int currentRomanNumeralValue = GetRomanNumeralValueAtIndex(i);
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
            int indexOfLowerRomanNumeral = _romanNumerals.IndexOfValue(lowerRomanNumeralValue);
            int upperRomanNumeralValue = GetRomanNumeralValueAtIndex(indexOfLowerRomanNumeral + 1);
            return upperRomanNumeralValue;
        }

        private static int GetLowerRomanNumeralValue(int input)
        {
            for (int i = _romanNumerals.Count - 1; i >= 0; i--)
            {
                int romanNumeralValue = GetRomanNumeralValueAtIndex(i);

                if (romanNumeralValue <= input)
                {
                    return romanNumeralValue;
                }
            }
            throw new Exception(Strings.Strings.LowerRomanNumeralNotFound);
        }

        private static int GetRomanNumeralValueAtIndex(int index)
        {
            return (int)_romanNumerals[index];
        }

        private static string GetRomanNumeralFromValue(int value)
        {
            return (string)_romanNumerals.GetKeyFromFirstElementWithValue(value);
        }
    }
}