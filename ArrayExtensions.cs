using System;

namespace Extentions
{
    public static class ArrayExtentions
    {
        public static string GetRandomElement(this string[] words)
        {
            Random random = new Random();
            return words[random.Next(0, words.Length)].ToString();
        }

    }
}