using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyRegex
    {
        static public MatchCollection myRegex_(string input, string pattern)
        {
            var regex = new Regex(pattern);
            MatchCollection match = regex.Matches(input);
            return match;
        }
        static public void PrintMatches(MatchCollection obj)
        {
            foreach (Match match in obj)
            {
                Console.WriteLine(match);
            }
        }
        static public void myRegex_replace(string input, string pattern, string replace = "[]")
        {

            var tmp_read = new StreamReader("Replace.txt");
            string tmp_read_ = "";
            tmp_read_ = tmp_read.ReadToEnd();
            tmp_read.Close();
            string replace_tmp = Regex.Replace(input, tmp_read_, replace);
            var wr = new StreamWriter("output.txt", false);
            wr.WriteLine(replace_tmp);
            wr.Close();

        }
        static public void Сoincidence(string input, string pattern)
        {
            var regex = new Regex(pattern);
            MatchCollection match = regex.Matches(input);
            var wr = new StreamWriter("output.txt", true);
            wr.WriteLine("Количесвто совпадений:" + match.Count.ToString());
            wr.Close();
        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            string text = "", pattern001 = "", tmp_input = "", tmp_pattern ="";

             try
            {
                text = args[0];
                var read = new StreamReader(text);
                tmp_input = read.ReadToEnd();
                read.Close();

                pattern001 = args[1];
                var read2 = new StreamReader(pattern001);
                tmp_pattern = read2.ReadToEnd();
                read2.Close();

                MyRegex.PrintMatches(MyRegex.myRegex_(tmp_input, tmp_pattern));
                MyRegex.myRegex_replace(tmp_input, tmp_pattern);
                MyRegex.Сoincidence(tmp_input, tmp_pattern);
            }
            catch
            {
                Console.WriteLine("Нет аргументов командной строки");
            }
            
            Console.ReadKey();
        }
    }
}
