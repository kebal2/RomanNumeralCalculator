using System;
using System.Runtime.Serialization;

namespace RomanNumerals
{
    [Serializable]
    public class LowerRomanNumeralNotFoundException : Exception
    {
        public LowerRomanNumeralNotFoundException()
        {
        }

        protected LowerRomanNumeralNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}