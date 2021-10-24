using System;
using System.Collections.Generic;

namespace Justifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var wr = new WordReader("./a.txt");
            char[] delimiters = { ' ', '\r', '\n', '\t'};
            int lineLength = 30;
            //List<string> words = new List<string>();

            //string word = wr.ReadWord(delimiters);
            //while ((word) != "")
            //{
            //    words.Add(word);
            //    word = wr.ReadWord(delimiters);
            //}
            //string[] input = words.ToArray();
            //wr.ReadWord(delimiters)

            string[] line = wr.ReadLine(lineLength, delimiters);
            WordProcessor js = new WordProcessor(lineLength, ".");
            Console.WriteLine(js.JustifyLine(line, justifyDirection.CENTER));
            while (!wr.endOfStream)
            {
                line = wr.ReadLine(lineLength, delimiters);
                Console.WriteLine(js.JustifyLine(line, justifyDirection.CENTER));
            }



            //Console.WriteLine(js.Justify(input, justifyDirection.LEFT));
            //Console.WriteLine(js.Justify(input, justifyDirection.RIGHT));
            //Console.WriteLine(js.JustifyLine(input, justifyDirection.CENTER));

        }
    }
}
