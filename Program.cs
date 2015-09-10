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
            string IntroductoryString;
            Parser parser = new Parser();
            List<string> text;
            for (; ; )
            {
                Console.Write("MyPerser.exe ");
                IntroductoryString = Console.ReadLine();
                text = parser.parsing(IntroductoryString);
                text = parser.helpcheking(text);

                while (text.Count != 0)
                {
                    switch (text[0])
                    {
                        case "/k":
                        case "-k": text = parser.keyvalue(text); break;
                        case "/ping":
                        case "-ping": text = parser.ping(text); break;
                        case "/print":
                        case "-print": text = parser.massege(text); break;
                        case "/exit":
                        case "-exit": parser.exit();break;
                        default: text = parser.error(text); break;
                    }

                }
            }
        }
    }
    class Parser
    {
       public List<string> parsing(string IntroductoryString)
        {
            
            string CurrentLine = "";
            List<string> text = new List<string>();
            if (IntroductoryString.Length != 0)
            {
                for (int index = 0; index < IntroductoryString.Length; index++)
                {
                    if (IntroductoryString[index].Equals(' ') || (index == (IntroductoryString.Length - 1)))
                    {
                        if (IntroductoryString[index] != ' ')
                            CurrentLine += IntroductoryString[index];
                        text.Add(CurrentLine);
                        CurrentLine = "";
                    }
                    else
                    {
                        CurrentLine += IntroductoryString[index];
                    }
                }
            }
            else
            {
                help();
            }
                return text;
        }

       public List<string> helpcheking(List<string> text)
       {
           bool FirstHelpCall = true;
           for (int i = 0; i < text.Count; i++)
           {
               if (text[i].Equals("-help") || text[i].Equals("-?") || text[i].Equals("/help") ||
                 text[i].Equals("/?") || text[i].Equals("-h") || text[i].Equals("/h"))
               {
                   text.RemoveAt(i);
                   if (FirstHelpCall)
                   {
                       help();
                       FirstHelpCall = false;
                   }
               }
           }
           return text;
       }

       public void help()
        {
            Console.WriteLine(@"-help, /h, -h, -?, /help, /? - this commands display help information.
    Use this command without any paramethers.
If you enter empty line, programm will the display help information too.
- ping, /ping - this command beeps. 
    Use this command without any paramethers.
- print <message>, /print <message > -this command print any messages, that you want to see.
    Example: -print I write my first message
- k <key value - value> or /k <key value - value> This command print keys and their values.
    Example: -key a alphabet
    a - alphabet
-exit or /exit - this commands end program.
");
        }

       public List<string> keyvalue(List<string> text)
        {
            bool isKey = true;
            text.RemoveAt(0);
            while (text.Count!=0)
            {
                if (text[0].Equals("-ping") || text[0].Equals("-print") || text[0].Equals("-k"))
                { break; }
                if (isKey)
                {
                    Console.Write(text[0] + " - ");
                    isKey = false;
                    text.RemoveAt(0);

                }
                else
                {
                    Console.WriteLine(text[0]);
                    isKey = true;
                    text.RemoveAt(0);
                }
            }
            if (isKey == false)
            {
                Console.WriteLine("null");
            }
            return text;
        }

       public List<string> ping(List<string> text)
        {
            Console.WriteLine("\aPinging ...");
            text.RemoveAt(0);
            return text;
        }

       public List<string> massege(List<string> text)
       {
           text.RemoveAt(0);
           while(text.Count!=0)
            {
                if (text[0].Equals("-ping") || text[0].Equals("-print") || text[0].Equals("-k"))
                { break; }
                Console.Write(text[0]);
                text.RemoveAt(0);
            }
            Console.WriteLine();
            return text;
        }

       public List<string> error(List<string> text)
       {
           Console.WriteLine("Command "+text[0]+" is not supported, use /? to see set of allowed commands"); 
           text.RemoveAt(0);
           return text;
       }

        public void exit()
        {
            Environment.Exit(0);
        }
    }
}
