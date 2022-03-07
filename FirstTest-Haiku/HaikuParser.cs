using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Text;
using FirstTest_Haiku.Util;

namespace FirstTest_Haiku
{
    public class HaikuParser
    {
        private readonly SyllableCounter syllableCounter;
        private readonly IConsoleWrapper consoleWrapper;

        public HaikuParser(SyllableCounter syllableCounter, IConsoleWrapper consoleWrapper)
        {
            this.syllableCounter = syllableCounter;
            this.consoleWrapper = consoleWrapper;
        }

        public void ParseHaikus(string haikus)
        {
            if (haikus == null)
            {
                throw new  ArgumentNullException($"Argument {nameof(haikus)} is null");
            }

            foreach (string haiku in haikus.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                consoleWrapper.WriteLine(ParseHaiku(haiku).ToString());
            }
        }

        public ResultOfParsingHaiku ParseHaiku(string haiku)
        {
            ResultOfParsingHaiku result = new ResultOfParsingHaiku()
            {
                Success = true
            };

            foreach (string line in haiku.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
            {

                result.SyllableCounts.Add(
                    line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Sum(syllableCounter.Count));
            }
            
            return result;
        }
    }

    public class ResultOfParsingHaiku
    {
        public List<int> SyllableCounts { get; } = new List<int>();

        private bool IsHaiku
        {
            get
            {
                return SyllableCounts.Count == 3 && SyllableCounts[0] == 5 && SyllableCounts[1] == 7 &&
                       SyllableCounts[2] == 5;
            }
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (int syllableCount in SyllableCounts)
            {
                builder.Append($"{syllableCount},");
            }

            builder.Append(IsHaiku ? "Yes" : "No");

            return builder.ToString();
        }
    }

 
}
