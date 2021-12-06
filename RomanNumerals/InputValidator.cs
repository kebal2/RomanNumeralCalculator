namespace RomanNumerals
{
    public static class InputValidator
    {
        public static bool IsInputValid(int currentInput, Boundaries boundaries)
        {
            return boundaries.Minimum <= currentInput && currentInput <= boundaries.Maximum;
        }

        public static bool IsInputValid(int currentInput)
        {
            return IsInputValid(currentInput, new Boundaries());
        }
    }
}