using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Parser parser = new Parser();
           
            for (; ; )
            {
                parser.parse(args);
            }
        }
    }
}
