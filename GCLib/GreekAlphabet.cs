using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCLib
{
    public class GreekAlphabet
    {
        private const char baseValue = '\u03b1';
        private const char capitalBaseValue = '\u0391';

        private static string[] lowerCase = new string[] {
            "alpha", "beta", "gamma", "delta", "epsilon",
            "zeta", "eta", "theta", "iota", "kappa", "lambda",
            "mu", "nu", "xi", "omicron", "pi", "rho", "sigma",
            "tau", "upsilon", "phi", "chi", "psi", "omega" };

        public static char? GetLowercase(string letter)
        {
            int index = GetIndex(letter);
            if (index >= 0)
                return (char)(baseValue + index);
            else
                return null;
        }

        public static char? GetUppercase(string letter)
        {
            int index = GetIndex(letter);
            if (index >= 0)
                return (char)(capitalBaseValue + index);
            else
                return null;
        }

        private static int GetIndex(string letter)
        {
            for (int i = 0; i < lowerCase.Length; i++)
            {
                if (lowerCase[i] == letter.ToLower())
                    return i;
            }
            return -1;
        }
    }
}
