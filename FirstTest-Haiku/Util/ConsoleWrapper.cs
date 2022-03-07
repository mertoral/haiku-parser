using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest_Haiku.Util
{
    public interface IConsoleWrapper
    {
        void WriteLine(string writeThis);
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string writeThis)
        {
            Console.WriteLine(writeThis);
        }
    }
}
