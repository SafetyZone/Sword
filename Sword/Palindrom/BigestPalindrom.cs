using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sword.Palindrom
{
    public class BigestPalindrom
    {
        /*
         * Imagine we have a large string like this "ABCBAHELLOHOWRACECARAREYOUIAMAIDOINGGOOD" which contains multiple 
         * palindromes within it, like ABCBA, RACECAR, ARA, IAMAI etc... Now write a method which will accept this large
         * string and return the largest palindrome from this string. If there are two palindromes which are of same size,
         * it would be sufficient to just return any one of them.
        */

        public string BigestPalimndrom(string str)
        {
            int lastIndex = str.Length - 1;

            for (int i = 0; i < str.Length; i++)
            {
                char a = str[i];

                if (a == str[lastIndex])
                {


                    int palLength = lastIndex - i;
                    int pei = lastIndex; // palimont end index
                    for (int psi = i; psi < palLength / 2; psi++) // palinom start index
                    {
                        while (true)
                        {
                            if (str[psi] == str[pei])
                            {
                                --pei;
                                break;
                            }
                            else
                            {
                                if (psi < pei)
                                {
                                    --pei;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static bool IsPalindrom(string str, int start, int end)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (start > end)
            {
                throw new ArgumentOutOfRangeException("start should not be greater than end");
            }

            if (end > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException("end greater than length");
            }

            if (end - start == 1)
            {
                return true;
            }

            if (str.Length == 1)
            {
                return false;
            }

            for (int i = start, j = end; i < str.Length / 2; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPalindrom(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length == 1)
            {
                return false;
            }

            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
