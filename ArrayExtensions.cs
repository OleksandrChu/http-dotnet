using System;

namespace Extentions
{
    public static class ArrayExtentions
    {
        public static string GetRandomElement(this string[] elements)
        {
            Random random = new Random();
            return elements[random.Next(0, elements.Length)].ToString();
        }

    }
}