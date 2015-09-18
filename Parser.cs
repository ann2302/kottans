using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
    class Parser
    {
        string username = "no name";
        public void parse(string [] args)
        {
            Console.Write("MyParser.exe ");
            List<string> text = args.ToList<string>();
            if (text.Count == 0)
            {
                string IntroductoryString;
                IntroductoryString = Console.ReadLine();
                text = IntroductoryString.Split(new Char[] { ' ' }).ToList<string>();
            }
            if (text.Count != 0)
            {
                while (text.Count != 0)
                {
                    switch (text[0])
                    {
                        case "/k":
                        case "-k": text = getkeyvalue(text); break;
                        case "/ping":
                        case "-ping": text = ping(text); break;
                        case "/print":
                        case "-print": text = print(text); break;
                        case "/exit":
                        case "-exit": exit(); break;
                        case "-help":
                        case "-?":
                        case "/help":
                        case "/?":
                        case "-h":
                        case "/h": text = help(text); break;
                        case "-setusername": text = setusername(text); break;
                        case "-getusername": text = getusername(text); break;
                        case "-sort":text = sort(text);break;
                        default: text = haveerror(text); break;
                    }
                }
            }
            else
            {
                help(text);

            }
        }

        public List<string> setusername(List<string> text)
        {
            text.RemoveAt(0);
            if (text.Count != 0)
            {
                username = text[0];
                text.RemoveAt(0);
            }
            return text;

        }

        public List<string> getusername(List<string> text)
        {
            text.RemoveAt(0);
            Console.WriteLine(username);
            return text;

        }

        public List<string> help(List<string> text)
        {
            if (text.Count != 0)
            {
                text.RemoveAt(0);
            }
            Console.WriteLine(@"-help, /h, -h, -?, /help, /? - this commands display help information.
    Use this command without paramethers.
If you enter empty line, programm will display help information too.
- ping, /ping - this command beeps. 
    Use this command without paramethers.
- print <message>, /print <message > -this command print all messages, that you want to see.
    Example: -print I write my first message
- k <key value - value> or /k <key value - value> This command print keys and their values.
    Example: -key a alphabet
    a - alphabet
-exit or /exit - this commands end program.
-setusername - this command set username.
-getusername - this command print name of user.
-sort - this comand use for sorting elements. 
Example:
-sort [a, b, c]
result:
c
b
a
");
            return text;
        }

        public List<string> getkeyvalue(List<string> text)
        {
            bool isKey = true;
            text.RemoveAt(0);
            while (text.Count != 0 && (text.Count != 0) &&
                (text[0] != "-ping") && (text[0] != "-print") &&
                (text[0] != "/ping") && (text[0] != "/print") &&
                (text[0] != "/exit") && (text[0] != "-exit") &&
                (text[0] != "-help") && (text[0] != "-?") &&
                (text[0] != "/help") && (text[0] != "/?") &&
                (text[0] != "-h") && (text[0] != "/h") &&(text[0] !="-sort")&&
                (text[0] != "-setusername") && (text[0] != "-getusername"))
            {
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

        public List<string> print(List<string> text)
        {
            text.RemoveAt(0);
            while (text.Count != 0 && (text.Count != 0)
                 && (text[0] != "-k") && (text[0] != "/k") &&
                 (text[0] != "/ping") &&
                 (text[0] != "/exit") && (text[0] != "-exit") &&
                 (text[0] != "-help") && (text[0] != "-?") &&
                 (text[0] != "/help") && (text[0] != "/?") &&
                 (text[0] != "-h") && (text[0] != "/h") && (text[0] != "-sort") &&
                 (text[0] != "-setusername") && (text[0] != "-getusername"))
            {
                Console.Write(text[0]);
                text.RemoveAt(0);
            }
            Console.WriteLine();
            return text;
        }

        public List<string> sort(List<string> text)
        {
            string StringOfSortinElements = "";
            text.RemoveAt(0);
            while (text.Count != 0 && (text.Count != 0)
                 && (text[0] != "-k") && (text[0] != "/k") &&
                 (text[0] != "/ping") && (text[0] != "-print") &&
                 (text[0] != "/exit") && (text[0] != "-exit") &&
                 (text[0] != "-help") && (text[0] != "-?") &&
                 (text[0] != "/help") && (text[0] != "/?") &&
                 (text[0] != "-h") && (text[0] != "/h") && (text[0] != "/print") &&
                 (text[0] != "-setusername") && (text[0] != "-getusername"))
            {
                StringOfSortinElements += text[0];
                text.RemoveAt(0);
            }
            List<string> SortingElements;
            if (StringOfSortinElements.Length != 0)
            {
                SortingElements = StringOfSortinElements.Split(new Char[] { ' ', '[', ']', ',', '.' }).ToList<string>();
                SortingElements.Sort();
                for(int i = SortingElements.Count -1; i >= 0; i--)
                {
                    Console.WriteLine(SortingElements[i]);
                }
            }
            else
            {
                Console.WriteLine("no elements");
            }
            return text;
        }

        public List<string> haveerror(List<string> text)
        {
            Console.WriteLine("Command " + text[0] + " is not supported, use /? to see set of allowed commands");
            text.RemoveAt(0);
            return text;
        }

        public void exit()
        {
            Environment.Exit(0);
        }
    }
}
