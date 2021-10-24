using System;
using System.Text;
namespace Justifier
{
    public class WordProcessor
    {
        int lineLength;
        string delimiter;

        public WordProcessor(int lineLength, string delimiter)
        {
            this.lineLength = lineLength;
            this.delimiter = delimiter;

        }
        public string JustifyLine(string[] words, justifyDirection justifyDirection)
        {
            StringBuilder sb = new StringBuilder();
            int numOfWords = words.Length;
            int totalNonWhiteCharLength = getNumOfNonWhiteChars(words);
            int numOfSpaces = lineLength - totalNonWhiteCharLength;

            int constSpace;
            int modularSpace;
            if (numOfWords > 1)
            {
                constSpace = numOfSpaces / (numOfWords - 1);
                modularSpace = numOfSpaces % (numOfWords - 1);
            }
            else
            {
                constSpace = numOfSpaces;
                modularSpace = 0;
            }

            switch (justifyDirection)
            {
                case justifyDirection.LEFT:
                    foreach (var word in words)
                    {
                        sb.Append(word);
                        sb.Append(delimiter);
                    }
                    sb.Remove(sb.Length - 1, 1);
                    break;
                case justifyDirection.RIGHT:
                    int numOfLeftSpaces = lineLength - totalNonWhiteCharLength - (numOfWords - 1);
                    for (int i = 1; i < numOfLeftSpaces; i++)
                    {
                        sb.Append(delimiter);
                    }
                    foreach (var word in words)
                    {
                        sb.Append(delimiter);
                        sb.Append(word);
                    }
                    break;
                case justifyDirection.CENTER:
                    for (int i = 0; i < numOfWords; i++)
                    {
                        sb.Append(words[i]);
                        for (int j = 0; j < constSpace; j++)
                        {
                            sb.Append(delimiter);
                        }
                        if (modularSpace > 0)
                        {
                            sb.Append(delimiter);
                        }
                        modularSpace--;
                    }
                    sb.Remove(sb.Length - constSpace, constSpace);
                    break;
            }
            string result = sb.ToString();
            return result;
        }

        private int getNumOfNonWhiteChars(string[] words)
        {
            int charCount = 0;
            foreach (var word in words)
            {
                charCount += word.Length;
            }
            return charCount;
        }
    }

    public enum justifyDirection
    {
        CENTER,
        LEFT,
        RIGHT
    }
}


