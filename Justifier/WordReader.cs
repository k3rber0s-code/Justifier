using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Justifier
{
    public class WordReader : TextReader, IWordReader
    {
        TextReader tr;
        //FileStream stream;
        string path;
        public bool endOfStream;
        public bool newParagraph;
        public WordReader(string path)
        {
            this.path = path;
            // stream = File.OpenRead(path);
            tr = File.OpenText(path);
            endOfStream = false;
        }
        //public void ReadText();
        public string[] ReadLine(int lineLength, char[] delimiters)
        {
            int totalCharacters = 0;

            List<string> words = new List<string>() ;
            string word = ReadWord(delimiters);
            totalCharacters += (word.Length);

            while (totalCharacters <= lineLength)
            {
                words.Add(word);
                word = ReadWord(delimiters);
                if (word == "" || word == "\n") break;
                totalCharacters += (word.Length + 1);
            }
            return words.ToArray();
        }
        public string ReadWord(char[] delimiters)
        {
            StringBuilder sb = new StringBuilder();
            int i = tr.Read();
            while (true)
            {
                char c = (char)i;
                if (i == -1)
                {
                    endOfStream = true;
                    break;
                }
                if (IsDelimiter(c, delimiters))
                {
                    break;
                }
                sb.Append(c);
                i = tr.Read();
            }
            return sb.ToString();
        }
        private bool IsDelimiter(char c, char[] delimiters)
        {
            foreach (char d in delimiters)
            {
                if (c == d) return true;
            }
            return false;
        }
    }
}
