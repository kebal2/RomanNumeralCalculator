namespace RomanNumerals.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE"); //Use this to test different languages.

            Boundaries b = new Boundaries();

            var introMessage = string.Format(Example.Resources.Messages.FirstMessageToUser, b.Minimum, b.Maximum, 0);
            OutputDisplayer.DisplayOutput(introMessage);

            int input;
            do
            {
                input = int.Parse(InputGatherer.GetInputFromUser());

                try
                {
                    var romanNumeral = input.AsRomanNumeral();

                    OutputDisplayer.DisplayOutput(romanNumeral);
                }
                catch (LowerRomanNumeralNotFoundException)
                {
                    OutputDisplayer.DisplayOutput(Resources.Messages.LowerRomanNumeralNotFound);
                }

                OutputDisplayer.DisplayOutput("");
            } while (input != 0);
        }
    }
}