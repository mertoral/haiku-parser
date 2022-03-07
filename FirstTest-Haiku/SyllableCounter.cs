using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest_Haiku
{
    public interface ISyllableCounter
    {
        int Count(string inThis);
    }

    public class SyllableCounter : ISyllableCounter
    {
        private static readonly char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u', 'y'};

        private bool IsVowel(char c)
        {
            return vowels.Contains(c);
        }

        public int Count(string inThis)
        {
            int count = 0;
            bool consecutive = false;

            foreach (var c in inThis)
            {
                if (IsVowel(c))
                {
                    if (!consecutive)
                    {
                        count++;
                    }

                    consecutive = true;
                }
                else
                {
                    consecutive = false;
                }
            }

            return count;
        }
    }
}
