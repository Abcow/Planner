using System;

namespace Planner.Framework
{
    public static class Extensions
    {
        public static string ToTitleCase(this string str)
        {
            var characters = new char[str.Length];
            bool capitaliseNext = true;
            
            for (int i = 0; i < str.Length; i++)
            {

                if (capitaliseNext)
                {
                    characters[i] = char.ToUpper(str[i]);
                }
                else
                {
                    characters[i] = str[i];
                }

                capitaliseNext = !char.IsLetter(str[i]);
            }

            return new string(characters);
        }

        public static int Abs(this int i) => Math.Abs(i);

        /// <summary>
        /// Gives the remainder of an integer division where the remainder is the same sign as the divisor.
        /// </summary>
        /// <param name="i">Quotient</param>
        /// <param name="j">Divisor</param>
        public static int DMod(this int i, int j)
        {
            int result = i % j;
            if ((result ^ j) > 0) result += j;

            return result;
        }

        /// <summary>
        /// Gives the result of an integer division where the remainder is the same sign as the divisor.
        /// </summary>
        /// <param name="i">Quotient</param>
        /// <param name="j">Divisor</param>
        public static int DDiv(this int i, int j)
        {
            int result = i / j;
            if ((result ^ j) > 0 && (i % j) != 0) result += j.GetSign();

            return result;
        }
        
        public static int GetSign(this int i) => (i == 0) ? 0 : i / i.Abs();
    }
}
