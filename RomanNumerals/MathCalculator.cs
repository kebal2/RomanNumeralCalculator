﻿namespace RomanNumerals
{
    internal static class MathCalculator
    {
        public static bool IsValuePowerOfTen(int value) => IsValuePowerOfX(10, value);

        private static bool IsValuePowerOfX(int x, int value)
        {
            while (value > x - 1 && value % x == 0) value /= x;
            return value == 1;
        }
    }
}