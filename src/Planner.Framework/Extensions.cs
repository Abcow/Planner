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


        public static int Mod(this int i, int j)
        {
            int result = i % j;
            if ((result ^ j) > 0) result += j;

            return result;
        }
    }
}
